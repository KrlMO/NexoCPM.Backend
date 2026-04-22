using MediatR;
using NexoCPM.Application.Auth.Ports;
using NexoCPM.Domain.Auth.Entities;

namespace NexoCPM.Application.Auth.Commands.RefreshToken
{
    public class RefreshTokenHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenResponseDto>
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

        public async Task<RefreshTokenResponseDto> Handle(RefreshTokenCommand command, CancellationToken ct)
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

            return new RefreshTokenResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken.Token
            };
        }
    }
}