using MediatR;
using NexoCPM.Application.Auth.Dtos;
using NexoCPM.Application.Auth.Ports;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Auth.Entities;

namespace NexoCPM.Application.Auth.Commands.RefreshToken
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenResult>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public RefreshTokenHandler(
            IRefreshTokenRepository refreshTokenRepository,
            IUserRepository userRepository,
            IJwtService jwtService)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<RefreshTokenResult> Handle(RefreshTokenCommand command, CancellationToken ct)
        {
            var refreshToken = await _refreshTokenRepository.GetByTokenAsync(command.RefreshToken);

            if (refreshToken == null)
                throw new UnauthorizedAccessException("Token inválido");

            if (refreshToken.Revoked || refreshToken.ExpiresAt < DateTime.UtcNow)
                throw new UnauthorizedAccessException("Token expirado o revocado");

            var user = await _userRepository.GetByIdAsync(refreshToken.UserId);

            if (user == null || !user.IsVerified)
                throw new UnauthorizedAccessException("Usuario no válido");

            await _refreshTokenRepository.RevokeAsync(refreshToken.Token);

            var newAccessToken = _jwtService.GenerateToken(user);

            var newRefreshToken = new Domain.Auth.Entities.RefreshToken(
                user.Id,
                Guid.NewGuid().ToString(),
                DateTime.UtcNow.AddDays(7),
                command.DeviceInfo,
                command.IpAddress
            );

            await _refreshTokenRepository.AddAsync(newRefreshToken);

            return new RefreshTokenResult
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken.Token,
                User = new AuthUserDto { 
                    Id = user.Id,
                    Email = user.Email,
                    AvatarUrl = user.AvatarUrl,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    UserRole = user.UserRole
                }
            };
        }
    }
}