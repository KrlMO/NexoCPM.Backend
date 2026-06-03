using MediatR;

namespace NexoCPM.Application.Evaluations.Queries.GetTestInfo
{
    public record GetTestInfoQuery(
        int UserId,
        int UserLearningContextId,
        string SyllabusSlug,
        string? UnitSlug
    ) : IRequest<GetTestInfoResponse>;
}
