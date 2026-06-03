using NexoCPM.Application.Commons.Dtos;
using NexoCPM.Application.Evaluations.Dtos;
using NexoCPM.Domain.Evaluations.Enums;

namespace NexoCPM.Application.Evaluations.Ports
{
    public interface IAssessmentRepository
    {
        Task<AssessmentDto?> GetAssessmentByTargetdAsync(int targetId, AssessmentScope assessmentScope, AssessmentType assessmentType);
        Task<PaginatedResult<SimulationAssessmentDto>> GetSimulationsPagedAsync(string? searchTerm, int page, int pageSize);
    }
}
