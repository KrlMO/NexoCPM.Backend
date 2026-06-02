using MediatR;
using NexoCPM.Application.Auth.Ports;
using NexoCPM.Application.Commons.Ports;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Common.Exceptions;

namespace NexoCPM.Application.Auth.Commands.ResetPassword
{
    public class ResetPasswordHandler : IRequestHandler<ResetPasswordCommand, ResetPasswordResult>
    {
        private readonly IPasswordResetTokenRepository _tokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITokenHasher _tokenHasher;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public ResetPasswordHandler(
            IPasswordResetTokenRepository tokenRepository,
            IUserRepository userRepository,
            ITokenHasher tokenHasher,
            IPasswordHasher passwordHasher,
            IRefreshTokenRepository refreshTokenRepository)
        {
            _tokenRepository = tokenRepository;
            _userRepository = userRepository;
            _tokenHasher = tokenHasher;
            _passwordHasher = passwordHasher;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<ResetPasswordResult> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
                throw new NotFoundException("No se encontró el usuario.");

            var tokenHash = _tokenHasher.Hash(request.Token);
            var token = await _tokenRepository.GetByTokenHashAsync(tokenHash);
            if (token == null)
                throw new UnauthorizedException("El enlace de recuperación no es válido.");

            if (!token.IsValid())
                throw new UnauthorizedException("El enlace de recuperación ha expirado o ya fue utilizado.");

            var newPasswordHash = _passwordHasher.Hash(request.NewPassword);
            user.ChangePassword(newPasswordHash);

            token.MarkAsUsed();

            await _userRepository.UpdateAsync(user);
            await _tokenRepository.UpdateAsync(token);
            await _refreshTokenRepository.RevokeAllByUserIdAsync(user.Id);

            return new ResetPasswordResult
            {
                Success = true,
                Message = "Tu contraseña ha sido cambiada correctamente."
            };
        }
    }
}
