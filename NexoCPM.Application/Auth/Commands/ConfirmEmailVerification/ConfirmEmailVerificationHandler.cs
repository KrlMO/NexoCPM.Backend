using MediatR;
using NexoCPM.Application.Auth.Ports;
using NexoCPM.Application.Commons.Ports;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Common.Exceptions;

namespace NexoCPM.Application.Auth.Commands.ConfirmEmailVerification
{
    public class ConfirmEmailVerificationHandler : IRequestHandler<ConfirmEmailVerificationCommand, ConfirmEmailVerificationResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailVerificationTokenRepository _emailVerificationTokenRepository;
        private readonly ITokenHasher _tokenHasher;

        public ConfirmEmailVerificationHandler(
            IUserRepository userRepository,
            IEmailVerificationTokenRepository emailVerificationTokenRepository,
            ITokenHasher tokenHasher)
        {
            _userRepository = userRepository;
            _emailVerificationTokenRepository = emailVerificationTokenRepository;
            _tokenHasher = tokenHasher;
        }

        public async Task<ConfirmEmailVerificationResult> Handle(ConfirmEmailVerificationCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.Email)
                ?? throw new NotFoundException("Usuario no encontrado");

            if (user.IsVerified)
                return new ConfirmEmailVerificationResult(true, request.Email);

            var tokenHash = _tokenHasher.Hash(request.Token);

            var emailToken = await _emailVerificationTokenRepository.GetByUserIdAndHashAsync(user.Id, tokenHash)
                ?? throw new NotFoundException("Token de verificación no encontrado");

            emailToken.MarkAsUsed();
            user.MarkEmailAsVerified();

            user.SetUpdated(1);

            await _emailVerificationTokenRepository.UpdateAsync(emailToken);
            await _userRepository.UpdateAsync(user);

            return new ConfirmEmailVerificationResult(true, request.Email);
        }
    }
}
