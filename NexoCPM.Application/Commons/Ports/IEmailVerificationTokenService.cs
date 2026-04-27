using NexoCPM.Domain.Auth.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Commons.Ports
{
    public interface IEmailVerificationTokenService
    {
        Task<(string token, string tokenHash)> GenerateAsync();
        Task<int> GetSecondsToResend(EmailVerificationToken emailToken);
    }
}
