using MediatR;
using NexoCPM.Application.Auth.Ports;
using NexoCPM.Application.Commons.Ports;
using NexoCPM.Domain.Auth.Entities;
using NexoCPM.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace NexoCPM.Application.Auth.Commands.Login
{
    public class LoginHandler : IRequestHandler<LoginCommand, LoginResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IJwtService _jwtService;
        private readonly IPasswordHasher _passwordHasher;

        public LoginHandler(IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository, IJwtService jwtService, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _jwtService = jwtService;
            _passwordHasher = passwordHasher;
        }

        public async Task<LoginResponseDto> Handle(LoginCommand command, CancellationToken ct)
        {
            var user = await _userRepository.GetByEmailAsync(command.Email);

            if (user == null)
                throw new UnauthorizedException("Credenciales inválidas");

            if (!user.IsVerified)
                throw new ForbiddenException("Debes verificar tu correo");

            if (!_passwordHasher.Verify(command.Password, user.GetPasswordHash()))
                throw new UnauthorizedException("Credenciales inválidas");

            var accessToken = _jwtService.GenerateToken(user);

            var refreshToken = new Domain.Auth.Entities.RefreshToken(
                user.Id,
                Guid.NewGuid().ToString(),
                DateTime.UtcNow.AddDays(7),
                command.DeviceInfo,
                command.IpAddress
            );

            await _refreshTokenRepository.AddAsync(refreshToken);

            return new LoginResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token
            };

        }
    }
}
