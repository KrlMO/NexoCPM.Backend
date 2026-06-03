using NexoCPM.Application.Commons.Dtos;
using NexoCPM.Application.Evaluations.Dtos;

namespace NexoCPM.Application.Evaluations.Queries.GetSimulations
{
    public class GetSimulationsResponse
    {
        public PaginatedResult<SimulationAssessmentDto> Simulations { get; set; } = new();
    }
}
