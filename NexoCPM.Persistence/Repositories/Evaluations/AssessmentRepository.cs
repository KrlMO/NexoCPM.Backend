using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Commons.Dtos;
using NexoCPM.Application.Evaluations.Dtos;
using NexoCPM.Application.Evaluations.Ports;
using NexoCPM.Domain.Evaluations.Enums;
using NexoCPM.Persistence.Context;

namespace NexoCPM.Persistence.Repositories.Evaluations
{
    public class AssessmentRepository : IAssessmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AssessmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AssessmentDto?> GetAssessmentByTargetdAsync(int targetId, AssessmentScope assessmentScope, AssessmentType assessmentType)
        {
            return await _context.Assessments
                .Where(a => a.Scope == assessmentScope && a.TargetId == targetId && a.IsActive && a.Type == assessmentType)
                .Select(a => new AssessmentDto
                {
                    Id = a.Id,
                    Description = string.Empty,
                    Code = a.Code,
                    AssessmentScope = a.Scope,
                    AssessmentType = a.Type,
                    TargetId = a.TargetId ?? 0
                })
                .FirstOrDefaultAsync();
        }

        public async Task<PaginatedResult<SimulationAssessmentDto>> GetSimulationsPagedAsync(string? searchTerm, int page, int pageSize)
        {
            var query = _context.Assessments
                .Where(a => a.Scope == AssessmentScope.SIMULATION
                         && a.Type == AssessmentType.KNOLEDGE
                         && a.IsActive
                         && a.TargetId != null);

            if (!string.IsNullOrWhiteSpace(searchTerm))
                query = query.Where(a => a.TargetId != null
                    && _context.Syllabi.Any(s => s.Id == a.TargetId && s.Name.Contains(searchTerm)));

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderBy(a => a.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(a => new SimulationAssessmentDto
                {
                    Id = a.Id,
                    Code = a.Code,
                    Title = "Simulacro de: " + _context.Syllabi
                        .Where(s => s.Id == a.TargetId)
                        .Select(s => s.Name)
                        .FirstOrDefault()!,
                    SyllabusName = _context.Syllabi
                        .Where(s => s.Id == a.TargetId)
                        .Select(s => s.Name)
                        .FirstOrDefault()!,
                    TargetId = a.TargetId ?? 0,
                    NumberQuestions = a.NumberQuestions,
                    TimeLimitSeconds = a.TimeLimitSeconds
                })
                .ToListAsync();

            return new PaginatedResult<SimulationAssessmentDto>
            {
                Items = items,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }
    }
}
