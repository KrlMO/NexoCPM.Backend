using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Users.Entities;
using NexoCPM.Persistence.Context;

namespace NexoCPM.Persistence.Repositories.Users;

public class UserSubTopicViewRepository : IUserSubTopicViewRepository
{
    private readonly ApplicationDbContext _context;

    public UserSubTopicViewRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task MarkAsViewedAsync(int userSyllabusUnitProgressId, int subTopicId)
    {
        var existing = await _context.Set<UserSubTopicView>()
            .FindAsync(userSyllabusUnitProgressId, subTopicId);

        if (existing is not null)
        {
            existing.MarkAsViewed();
        }
        else
        {
            _context.Set<UserSubTopicView>().Add(
                new UserSubTopicView(userSyllabusUnitProgressId, subTopicId));
        }

        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsViewedAsync(int userSyllabusUnitProgressId, int subTopicId)
    {
        return await _context.Set<UserSubTopicView>()
            .AnyAsync(ustv =>
                ustv.UserSyllabusUnitProgressId == userSyllabusUnitProgressId &&
                ustv.SubTopicId == subTopicId &&
                ustv.IsViewed);
    }
}
