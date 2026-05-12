using MediatR;
using NexoCPM.Application.Auth.Dtos;
using NexoCPM.Application.Auth.Ports;
using NexoCPM.Application.Commons.Ports;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Auth.Entities;
using NexoCPM.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NexoCPM.Application.Auth.Commands.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IJwtService _jwtService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenHasher _tokenHasher;

        public LoginHandler(IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository, IJwtService jwtService, IPasswordHasher passwordHasher, ITokenHasher tokenHasher)
        {
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _jwtService = jwtService;
            _passwordHasher = passwordHasher;
            _tokenHasher = tokenHasher;
        }

        public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
                throw new NotFoundException("Este correo no está asociado a ninguna cuenta.");

            if (!user.IsActive)
                throw new ForbiddenException("Tu cuenta está inactiva. Contacta al soporte.");

            if (!user.IsVerified)
                throw new ForbiddenException("Debes verificar tu correo");

            if (!_passwordHasher.Verify(request.Password, user.GetPasswordHash()))
                throw new UnauthorizedException("Credenciales inválidas");


            var accessToken = _jwtService.GenerateToken(user);

            var rawToken = Guid.NewGuid().ToString();
            var hashedToken = _tokenHasher.Hash(rawToken);

            var refreshToken = new Domain.Auth.Entities.RefreshToken(
                user.Id,
                hashedToken,
                DateTime.UtcNow.AddDays(7),
                request.DeviceInfo,
                request.IpAddress
            );

            await _refreshTokenRepository.AddAsync(refreshToken);

            return new LoginResult
            {
                RefreshToken = rawToken,
                AccessToken = accessToken,
                User = new AuthUserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    AvatarUrl = user.AvatarUrl,
                    UserRole = user.UserRole
                }
            };

        }
    }
}
