using NexoCPM.Application.Users.Dtos;

namespace NexoCPM.Application.Users.Ports;

public interface IUserProgressRepository
{
    Task<List<GetDashboardSyllabusDto>> GetActiveSyllabusProgressAsync(int userId);
    Task<decimal> GetOverallProgressPercentageAsync(int userId);
}
