using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Users.Entities;
using NexoCPM.Persistence.Context;

namespace NexoCPM.Persistence.Repositories.Users;

public class UserSyllabusUnitProgressRepository : IUserSyllabusUnitProgressRepository
{
    private readonly ApplicationDbContext _context;

    public UserSyllabusUnitProgressRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserSyllabusUnitProgress?> GetByProgressAndUnitAsync(int userSyllabusProgressId, int syllabusUnitId)
    {
        return await _context.UserSyllabusUnitProgresses
            .FirstOrDefaultAsync(usup =>
                usup.UserSyllabusProgressId == userSyllabusProgressId &&
                usup.SyllabusUnitId == syllabusUnitId);
    }

    public async Task<UserSyllabusUnitProgress> AddAsync(UserSyllabusUnitProgress progress)
    {
        _context.UserSyllabusUnitProgresses.Add(progress);
        await _context.SaveChangesAsync();
        return progress;
    }

    public async Task UpdateAsync(UserSyllabusUnitProgress progress)
    {
        _context.UserSyllabusUnitProgresses.Update(progress);
        await _context.SaveChangesAsync();
    }
}
