using NexoCPM.Application.Context.Dtos;

namespace NexoCPM.Application.Context.Ports
{
    public interface ILevelRepository
    {
        Task<List<LevelDto>> GetAllActiveAsync();
    }
}
