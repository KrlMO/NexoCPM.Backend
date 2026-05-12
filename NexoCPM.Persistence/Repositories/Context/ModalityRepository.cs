using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Context.Dtos;
using NexoCPM.Application.Context.Ports;
using NexoCPM.Persistence.Context;

namespace NexoCPM.Persistence.Repositories.Context;

public class ModalityRepository : IModalityRepository
{
    private readonly ApplicationDbContext _context;

    public ModalityRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<ModalityDto>> GetAllActiveAsync()
    {
        return await _context.Modalities
            .Where(m => m.IsActive && !m.IsDeleted)
            .OrderBy(m => m.Code)
            .Select(m => new ModalityDto
            {
                Id = m.Id,
                Code = m.Code,
                Name = m.Name,
                Slug = m.Slug
            })
            .ToListAsync();
    }
}
