using NexoCPM.Application.Context.Dtos;

namespace NexoCPM.Application.Context.Ports
{
    public interface IModalityRepository
    {
        Task<List<ModalityDto>> GetAllActiveAsync();
    }
}
