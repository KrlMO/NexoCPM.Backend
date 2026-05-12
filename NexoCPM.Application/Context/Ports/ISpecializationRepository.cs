using NexoCPM.Application.Context.Dtos;

namespace NexoCPM.Application.Context.Ports
{
    public interface ISpecializationRepository
    {
        Task<List<SpecializationDto>> GetAllActiveAsync();
    }
}
