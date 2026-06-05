using MediatR;

namespace NexoCPM.Application.Evaluations.Queries.GetTestHistory
{
    public record GetTestHistoryQuery(
        int UserId,
        int UserLearningContextId,
        string SyllabusSlug,
        string? UnitSlug
    ) : IRequest<GetTestHistoryResponse>;
}
