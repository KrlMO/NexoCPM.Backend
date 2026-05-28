using NexoCPM.Application.Commons.Dtos;
using NexoCPM.Application.Users.Dtos;

namespace NexoCPM.Application.Users.Ports;

public interface IUserProgressRepository
{
    Task<List<DashboardSyllabusDto>> GetActiveSyllabusProgressAsync(int userId);
    Task<List<SyllabusProgressDto>> GetSyllabiProgressAsync(int userId);
    Task<List<UnitProgressDto>> GetUnitProgressAsync(int userLearningContextId);
    Task<decimal> GetOverallProgressPercentageAsync(int userId);
    Task<int> GetTestCountAsync(int userId);
    Task<int> GetSimulationCountAsync(int userId);
}
