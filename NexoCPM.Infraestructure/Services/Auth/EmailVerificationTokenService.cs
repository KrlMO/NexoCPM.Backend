using NexoCPM.Application.Commons.Ports;
using NexoCPM.Domain.Auth.Entities;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace NexoCPM.Infraestructure.Services.Auth
{
    public class EmailVerificationTokenService : IEmailVerificationTokenService
    {
        public Task<(string token, string tokenHash)> GenerateAsync()
        {
            var bytes = RandomNumberGenerator.GetBytes(32);
            var token = Convert.ToBase64String(bytes);

            using var sha256 = SHA256.Create();
            var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(token));
            var tokenHash = Convert.ToBase64String(hashBytes);

            return Task.FromResult((token, tokenHash));
        }

        public Task<int> GetSecondsToResend(EmailVerificationToken emailToken)
        {
            int seconds = 0;

            seconds = (int)(emailToken.CreatedAt.AddMinutes(2) - DateTime.UtcNow).TotalSeconds;
            if (seconds < 0) seconds = 0;
            return Task.FromResult(seconds);
        }
    }
}
