using NexoCPM.Domain.Auth.Entities;

namespace NexoCPM.Application.Auth.Ports
{
    public interface IPasswordResetTokenRepository
    {
        Task AddAsync(PasswordResetToken token);
        Task<PasswordResetToken?> GetByTokenHashAsync(string tokenHash);
        Task<PasswordResetToken?> GetValidByUserIdAsync(int userId);
        Task UpdateAsync(PasswordResetToken token);
    }
}
