using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Context.Dtos;
using NexoCPM.Application.Context.Ports;
using NexoCPM.Persistence.Context;

namespace NexoCPM.Persistence.Repositories.Context;

public class LevelRepository : ILevelRepository
{
    private readonly ApplicationDbContext _context;

    public LevelRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<LevelDto>> GetAllActiveAsync()
    {
        return await _context.Levels
            .Where(l => l.IsActive && !l.IsDeleted)
            .OrderBy(l => l.Code)
            .Select(l => new LevelDto
            {
                Id = l.Id,
                Code = l.Code,
                Name = l.Name,
                Slug = l.Slug
            })
            .ToListAsync();
    }
}
