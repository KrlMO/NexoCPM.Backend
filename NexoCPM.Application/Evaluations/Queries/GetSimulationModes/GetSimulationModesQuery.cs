using MediatR;

namespace NexoCPM.Application.Evaluations.Queries.GetSimulationModes
{
    public record GetSimulationModesQuery(
        int UserId,
        int AssessmentId
    ) : IRequest<GetSimulationModesResponse>;
}
