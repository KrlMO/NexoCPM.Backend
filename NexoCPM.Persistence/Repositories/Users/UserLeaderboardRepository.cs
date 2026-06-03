using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Users.Entities;
using NexoCPM.Persistence.Context;

namespace NexoCPM.Persistence.Repositories.Users;

public class UserLeaderboardRepository : IUserLeaderboardRepository
{
    private readonly ApplicationDbContext _context;

    public UserLeaderboardRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserLeaderboard?> GetByUserIdAsync(int userId)
    {
        return await _context.Set<UserLeaderboard>()
            .FirstOrDefaultAsync(ul => ul.UserId == userId);
    }

        public async Task<int> GetRankByTotalStarsAsync(int totalStars)
        {
            var usersWithMoreStars = await _context.Set<UserLeaderboard>()
                .CountAsync(ul => ul.TotalStars > totalStars);

            return usersWithMoreStars + 1;
        }

        public async Task<List<UserLeaderboard>> GetTopUsersAsync(int count)
        {
            return await _context.Set<UserLeaderboard>()
                .Include(ul => ul.User)
                .Where(ul => ul.User.IsActive && !ul.User.IsDeleted && ul.User.IsPublic)
                .OrderByDescending(ul => ul.TotalStars)
                .ThenBy(ul => ul.User.FirstName)
                .Take(count)
                .AsNoTracking()
                .ToListAsync();
        }
    }
