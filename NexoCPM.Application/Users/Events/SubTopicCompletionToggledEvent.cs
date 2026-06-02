using MediatR;

namespace NexoCPM.Application.Users.Events
{
    public record SubTopicCompletionToggledEvent(
        int UserId,
        int UserSyllabusUnitProgressId,
        int SyllabusUnitId,
        int UserLearningContextId
    ) : INotification;
}
