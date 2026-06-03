using MediatR;

namespace NexoCPM.Application.Evaluations.Queries.GetSimulations
{
    public record class GetSimulationsQuery(
        string? searchTerm,
        int page = 1,
        int pageSize = 10) : IRequest<GetSimulationsResponse>;
}
