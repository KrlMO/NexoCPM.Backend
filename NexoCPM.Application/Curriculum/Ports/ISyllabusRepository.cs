using NexoCPM.Application.Commons.Dtos;
using NexoCPM.Application.Curriculum.Dtos;
using NexoCPM.Domain.Curriculum.Entities;

namespace NexoCPM.Application.Curriculum.Ports
{
    public interface ISyllabusRepository
    {
        Task<List<DashboardSyllabusDto>> GetFeaturedSyllabiAsync();
        Task<PaginatedResult<SyllabusDto>> GetSyllabiAsync(string? searchTerm, string? modalitySlug, string? levelSlug, string? specializationSlug, int page, int pageSize);
        Task<Syllabus?> GetBySlugAsync(string slug);
    }
}
