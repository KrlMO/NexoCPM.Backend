using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Users.Entities;
using NexoCPM.Persistence.Context;

namespace NexoCPM.Persistence.Repositories.Users;

public class UserSyllabusProgressRepository : IUserSyllabusProgressRepository
{
    private readonly ApplicationDbContext _context;

    public UserSyllabusProgressRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserSyllabusProgress?> GetByLearningContextAsync(int userLearningContextId)
    {
        return await _context.UserSyllabusProgresses
            .FirstOrDefaultAsync(usp => usp.UserLearningContextId == userLearningContextId);
    }

    public async Task UpdateAsync(UserSyllabusProgress progress)
    {
        _context.UserSyllabusProgresses.Update(progress);
        await _context.SaveChangesAsync();
    }
}
