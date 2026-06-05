using MediatR;

namespace NexoCPM.Application.Evaluations.Queries.GetAttemptDetail
{
    public record GetAttemptDetailQuery(
        int UserId,
        int UserLearningContextId,
        int AttemptId
    ) : IRequest<GetAttemptDetailResponse>;
}
