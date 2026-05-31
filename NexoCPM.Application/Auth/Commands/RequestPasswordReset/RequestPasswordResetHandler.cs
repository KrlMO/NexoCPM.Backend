using MediatR;
using NexoCPM.Application.Auth.Ports;
using NexoCPM.Application.Commons.Ports;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Auth.Entities;
using NexoCPM.Domain.Common.Exceptions;

namespace NexoCPM.Application.Auth.Commands.RequestPasswordReset
{
    public class RequestPasswordResetHandler : IRequestHandler<RequestPasswordResetCommand, RequestPasswordResetResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordResetTokenRepository _tokenRepository;
        private readonly IPasswordResetTokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public RequestPasswordResetHandler(
            IUserRepository userRepository,
            IPasswordResetTokenRepository tokenRepository,
            IPasswordResetTokenService tokenService,
            IEmailService emailService,
            IRefreshTokenRepository refreshTokenRepository)
        {
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
            _tokenService = tokenService;
            _emailService = emailService;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<RequestPasswordResetResult> Handle(RequestPasswordResetCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
                throw new NotFoundException("Este correo no está asociado a ninguna cuenta.");

            var existing = await _tokenRepository.GetValidByUserIdAsync(user.Id);
            if (existing != null)
            {
                var secondsSinceCreation = (DateTime.UtcNow - existing.CreatedAt).TotalSeconds;
                if (secondsSinceCreation < 60)
                    throw new ConflictException("Ya se envió un enlace de recuperación recientemente. Espera un minuto antes de solicitar otro.");
            }

            await _refreshTokenRepository.RevokeAllByUserIdAsync(user.Id);

            var (rawToken, tokenHash) = await _tokenService.GenerateAsync();
            var expiresAt = DateTime.UtcNow.AddMinutes(30);

            var resetToken = new PasswordResetToken(
                user.Id, tokenHash, expiresAt,
                request.IpAddress, request.DeviceInfo
            );

            await _tokenRepository.AddAsync(resetToken);
            await _emailService.SendPasswordResetEmailAsync(user.Email, rawToken);

            return new RequestPasswordResetResult
            {
                Success = true,
                Message = "Se ha enviado un enlace de recuperación a tu correo electrónico."
            };
        }
    }
}
