using MediatR;
using NexoCPM.Application.Auth.Ports;
using NexoCPM.Application.Commons.Ports;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Auth.Entities;
using NexoCPM.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Auth.Commands.VerifyEmailVerification
{
    public class VerifyEmailVerificationHandler : IRequestHandler<VerifyEmailVerificationCommand, VerifyEmailVerificationResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailVerificationTokenRepository _emailVerificationTokenRepository;
        private readonly IEmailVerificationTokenService _emailVerificationTokenService;

        public VerifyEmailVerificationHandler(IUserRepository userRepository, IEmailVerificationTokenRepository emailVerificationTokenRepository, IEmailVerificationTokenService emailVerificationTokenService)
        {
            _userRepository = userRepository;
            _emailVerificationTokenRepository = emailVerificationTokenRepository;
            _emailVerificationTokenService = emailVerificationTokenService;
        }
        public async Task<VerifyEmailVerificationResult> Handle(VerifyEmailVerificationCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.email);

            if (user == null) {
                throw new NotFoundException("Usuario no encontrado");
            }

            if (user.IsVerified)
            {
                return new VerifyEmailVerificationResult
                {
                    IsUsed = false,
                    TimeToResendSeconds = 0,
                    EmailVerified = true,
                    EmailExists = true,
                    CanResend = false
                };
            }

            var emailToken = await _emailVerificationTokenRepository.GetByUserIdAsync(user.Id);

            if (emailToken  == null) { // por algun motivo existe el usuario no verificado, pero no existe registro de token, se asume que es un error, por lo se le notifica al cliente que puede reenviar el correo
                return new VerifyEmailVerificationResult
                {
                    IsUsed = false,
                    TimeToResendSeconds = 0,
                    EmailVerified = false,
                    EmailExists = true,
                    CanResend = true
                };
            }

            int secondsToResend = await _emailVerificationTokenService.GetSecondsToResend(emailToken);
            return new VerifyEmailVerificationResult
            {
                IsUsed = emailToken.IsUsed,
                TimeToResendSeconds = secondsToResend,
                EmailVerified = false,
                EmailExists = true,
                CanResend = secondsToResend == 0
            };
        }
    }
}
