using MediatR;

namespace NexoCPM.Application.Evaluations.Commands.StartAssessmentAttempt
{
    public record StartAssessmentAttemptTestCommand(
        int UserId,
        int UserLearningContextId,
        int AssessmentId
    ) : IRequest<StartAssessmentAttemptTestResponse>;
}
