using MediatR;

namespace NexoCPM.Application.Users.Events
{
    public record UnitProgressUpdatedEvent(
        int UserId,
        int SyllabusId,
        int UserLearningContextId
    ) : INotification;
}
