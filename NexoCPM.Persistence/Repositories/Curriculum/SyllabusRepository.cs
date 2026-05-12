using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Commons.Dtos;
using NexoCPM.Application.Curriculum.Dtos;
using NexoCPM.Application.Curriculum.Ports;
using NexoCPM.Domain.Curriculum.Entities;
using NexoCPM.Persistence.Context;

namespace NexoCPM.Persistence.Repositories.Curriculum;

public class SyllabusRepository : ISyllabusRepository
{
    private readonly ApplicationDbContext _context;

    public SyllabusRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Syllabus?> GetBySlugAsync(string slug)
    {
        return await _context.Syllabi
            .AsNoTracking()
            .FirstOrDefaultAsync(s => s.Slug == slug && s.IsActive && !s.IsDeleted);
    }

    public async Task<List<DashboardSyllabusDto>> GetFeaturedSyllabiAsync()
    {
        return await _context.Syllabi
            .Where(s => s.IsActive && !s.IsDeleted)
            .OrderByDescending(s => s.UserLearningContexts.Count)
            .Take(4)
            .Select(s => new DashboardSyllabusDto
            {
                Id = s.Id,
                Code = s.Code,
                Slug = s.Slug,
                Name = s.Name,
            })
            .ToListAsync();
    }

    public async Task<PaginatedResult<SyllabusDto>> GetSyllabiAsync(string? searchTerm, string? modalitySlug, string? levelSlug, string? specializationSlug, int page, int pageSize)
    {
        var query = _context.Syllabi
            .Where(s => s.IsActive && !s.IsDeleted);

        if (!string.IsNullOrWhiteSpace(modalitySlug))
            query = query.Where(s => s.SyllabusContexts.Any(sc =>
                sc.EducationContext.Level.Modality.Slug == modalitySlug));

        if (!string.IsNullOrWhiteSpace(levelSlug))
            query = query.Where(s => s.SyllabusContexts.Any(sc =>
                sc.EducationContext.Level.Slug == levelSlug));

        if (!string.IsNullOrWhiteSpace(specializationSlug))
            query = query.Where(s => s.SyllabusContexts.Any(sc =>
                sc.EducationContext.Specialization != null && sc.EducationContext.Specialization.Slug == specializationSlug));

        if (!string.IsNullOrWhiteSpace(searchTerm))
            query = query.Where(s => s.Name.Contains(searchTerm));

        var totalCount = await query.CountAsync();

        var items = await query
            .OrderBy(s => s.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(s => new SyllabusDto
            {
                Id = s.Id,
                Code = s.Code,
                Name = s.Name,
                Slug = s.Slug
            })
            .ToListAsync();

        return new PaginatedResult<SyllabusDto>
        {
            Items = items,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        };
    }
}
