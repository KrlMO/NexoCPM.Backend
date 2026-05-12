using NexoCPM.Application.Commons.Dtos;

namespace NexoCPM.Application.Users.Ports;

public interface IUserProgressRepository
{
    Task<List<DashboardSyllabusDto>> GetActiveSyllabusProgressAsync(int userId);
    Task<decimal> GetOverallProgressPercentageAsync(int userId);
    Task<int> GetTestCountAsync(int userId);
    Task<int> GetSimulationCountAsync(int userId);
}
