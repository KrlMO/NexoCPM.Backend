using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Context.Dtos;
using NexoCPM.Application.Context.Ports;
using NexoCPM.Persistence.Context;

namespace NexoCPM.Persistence.Repositories.Context;

public class SpecializationRepository : ISpecializationRepository
{
    private readonly ApplicationDbContext _context;

    public SpecializationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SpecializationDto>> GetAllActiveAsync()
    {
        return await _context.Specializations
            .Where(s => s.IsActive && !s.IsDeleted && s.Code!="GENEN")
            .OrderBy(s => s.Code)
            .Select(s => new SpecializationDto
            {
                Id = s.Id,
                Code = s.Code,
                Name = s.Name,
                Slug = s.Slug
            })
            .ToListAsync();
    }
}
