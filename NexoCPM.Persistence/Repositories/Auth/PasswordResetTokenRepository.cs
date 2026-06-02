using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Auth.Ports;
using NexoCPM.Domain.Auth.Entities;
using NexoCPM.Persistence.Context;

namespace NexoCPM.Persistence.Repositories.Auth
{
    public class PasswordResetTokenRepository : IPasswordResetTokenRepository
    {
        private readonly ApplicationDbContext _context;

        public PasswordResetTokenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(PasswordResetToken token)
        {
            await _context.PasswordResetTokens.AddAsync(token);
            await _context.SaveChangesAsync();
        }

        public async Task<PasswordResetToken?> GetByTokenHashAsync(string tokenHash)
        {
            return await _context.PasswordResetTokens
                .FirstOrDefaultAsync(t => t.TokenHash == tokenHash);
        }

        public async Task<PasswordResetToken?> GetValidByUserIdAsync(int userId)
        {
            var now = DateTime.UtcNow;
            return await _context.PasswordResetTokens
                .FirstOrDefaultAsync(t => t.UserId == userId && !t.IsUsed && t.ExpiresAt > now);
        }

        public async Task UpdateAsync(PasswordResetToken token)
        {
            _context.PasswordResetTokens.Update(token);
            await _context.SaveChangesAsync();
        }
    }
}
