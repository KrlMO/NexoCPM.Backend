using MediatR;
using NexoCPM.Application.Auth.Ports;
using NexoCPM.Application.Commons.Ports;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Auth.Entities;
using NexoCPM.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Auth.Commands.ResendEmailVerification
{
    public class ResendEmailVerificationHandler : IRequestHandler<ResendEmailVerificationCommand, ResendEmailVerificationResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailVerificationTokenRepository _emailVerificationTokenRepository;
        private readonly IEmailVerificationTokenService _emailVerificationTokenService;
        private readonly IEmailService _emailService;

        public ResendEmailVerificationHandler(IUserRepository userRepository,
            IEmailVerificationTokenRepository emailVerificationTokenRepository,
            IEmailVerificationTokenService emailVerificationTokenService,
            IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailVerificationTokenRepository = emailVerificationTokenRepository;
            _emailVerificationTokenService = emailVerificationTokenService;
            _emailService = emailService;
        }
        public async Task<ResendEmailVerificationResult> Handle(ResendEmailVerificationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetByEmailAsync(request.Email)?? throw new Exception("User not found");

                var existingToken = await _emailVerificationTokenRepository.GetByUserIdAsync(user.Id);

                if (existingToken != null)
                {
                    existingToken.Invalidate();
                    await _emailVerificationTokenRepository.UpdateAsync(existingToken);
                }

                var (token, tokenHash) = await _emailVerificationTokenService.GenerateAsync();

                var newToken = new EmailVerificationToken(
                    user.Id,
                    tokenHash,
                    DateTime.UtcNow.AddHours(24)
                );

                await _emailVerificationTokenRepository.AddAsync(newToken);

                await _emailService.SendVerificationEmailAsync(user.Email, token);

                return new ResendEmailVerificationResult(true);
            }
            catch (Exception) {
                throw;
            }
        }
    }
}
