using MediatR;

namespace NexoCPM.Application.Users.Events
{
    public record UnitProgressUpdatedEvent(
        int UserId,
        int SyllabusId
    ) : INotification;
}
