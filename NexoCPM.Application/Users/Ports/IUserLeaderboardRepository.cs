using NexoCPM.Domain.Users.Entities;

namespace NexoCPM.Application.Users.Ports
{
    public interface IUserLeaderboardRepository
    {
        Task<UserLeaderboard?> GetByUserIdAsync(int userId);
        Task<int> GetRankByTotalStarsAsync(int totalStars);
        Task<List<UserLeaderboard>> GetTopUsersAsync(int count);
    }
}
