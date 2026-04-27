using NexoCPM.Domain.Auth.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Auth.Ports
{
    public interface IEmailVerificationTokenRepository
    {
        Task AddAsync(EmailVerificationToken token);
        Task<EmailVerificationToken?> GetByUserIdAsync(int userId);
        Task<EmailVerificationToken?> GetByEmailAsync(string email);
        Task UpdateAsync(EmailVerificationToken token);
    }
}
