using MediatR;

namespace NexoCPM.Application.Evaluations.Commands.StartAssessmentAttempt
{
    public record StartAssessmentAttemptCommand(
        int UserId,
        int UserLearningContextId,
        int AssessmentId
    ) : IRequest<StartAssessmentAttemptResponse>;
}
