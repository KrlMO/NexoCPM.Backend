using NexoCPM.Application.Commons.Dtos;
using NexoCPM.Application.Evaluations.Dtos;
using NexoCPM.Application.Users.Dtos;

namespace NexoCPM.Application.Evaluations.Ports
{
    public interface IAssessmentAttemptRepository
    {
        Task<List<SimulationDto>> GetLastSimulationsAsync(int userId, int count);
        Task<List<string>> GetTopFailedSubtopicsAsync(int userId, int topCount);
        Task<List<AssessmentChartDto>> GetLastTestChartDataAsync(int userId, int count);
        Task<List<AssessmentChartDto>> GetLastSimulationChartDataAsync(int userId, int count);
        Task<List<RecommendationDto>> GetFailedSubtopicsAsync(int userLearningContextId, int count);
        Task<PaginatedResult<SimulationHistoryDto>> GetSimulationHistoryAsync(int userId, int page, int pageSize);
    }
}

