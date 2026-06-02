using MediatR;

namespace NexoCPM.Application.Users.Commands.ToggleSubTopicCompletion
{
    public record ToggleSubTopicCompletionCommand(int SubTopicId) : IRequest<ToggleSubTopicCompletionResult>
    {
        public int UserId { get; init; }
        public int UserLearningContextId { get; init; }
    }
}
