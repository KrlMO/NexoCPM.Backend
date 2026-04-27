using NexoCPM.Application.Auth.Ports;
using NexoCPM.Domain.Auth.Entities;
using NexoCPM.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace NexoCPM.Persistence.Repositories.Auth
{
    public class EmailVerificationTokenRepository : IEmailVerificationTokenRepository
    {
        private readonly ApplicationDbContext _context;

        public EmailVerificationTokenRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(EmailVerificationToken emailVerificationToken) {
            await _context.EmailVerificationTokens.AddAsync(emailVerificationToken);
            await _context.SaveChangesAsync();
        }

        public async Task<EmailVerificationToken?> GetByEmailAsync(string email)
        {
            return await _context.EmailVerificationTokens
                .FirstOrDefaultAsync(evt => evt.User.Email == email && !evt.IsUsed);
        }

        public async Task<EmailVerificationToken?> GetByUserIdAsync(int userId)
        {
            return await _context.EmailVerificationTokens.FirstOrDefaultAsync(t => t.UserId == userId && !t.IsUsed);
        }

        public async Task UpdateAsync(EmailVerificationToken token)
        {
            _context.EmailVerificationTokens.Update(token);
            await _context.SaveChangesAsync();
        }
    }
}
