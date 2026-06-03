using NexoCPM.Application.Commons.Dtos;
using NexoCPM.Application.Evaluations.Dtos;

namespace NexoCPM.Application.Evaluations.Queries.GetSimulationHistory
{
    public class GetSimulationHistoryResponse
    {
        public PaginatedResult<SimulationHistoryDto> History { get; set; } = new();
    }
}
