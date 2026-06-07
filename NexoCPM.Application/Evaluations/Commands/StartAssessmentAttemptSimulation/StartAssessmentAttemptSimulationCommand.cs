using MediatR;
using NexoCPM.Domain.Evaluations.Enums;

namespace NexoCPM.Application.Evaluations.Commands.StartAssessmentAttemptSimulation
{
    public record StartAssessmentAttemptSimulationCommand(
        int UserId,
        int AssessmentId,
        AssessmentGenerationMode GenerationMode
    ) : IRequest<StartAssessmentAttemptSimulationResponse>;
}
