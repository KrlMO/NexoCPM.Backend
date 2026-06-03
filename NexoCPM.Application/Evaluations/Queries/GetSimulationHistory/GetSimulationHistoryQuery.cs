using MediatR;

namespace NexoCPM.Application.Evaluations.Queries.GetSimulationHistory
{
    public record GetSimulationHistoryQuery(
        int UserId,
        int Page = 1,
        int PageSize = 5) : IRequest<GetSimulationHistoryResponse>;
}
