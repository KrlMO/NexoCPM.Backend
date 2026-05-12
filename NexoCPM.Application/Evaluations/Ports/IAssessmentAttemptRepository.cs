using NexoCPM.Application.Users.Dtos;

namespace NexoCPM.Application.Evaluations.Ports
{
    public interface IAssessmentAttemptRepository
    {
        Task<List<SimulationDto>> GetLastSimulationsAsync(int userId, int count);
        Task<List<string>> GetTopFailedSubtopicsAsync(int userId, int topCount);
    }
}

