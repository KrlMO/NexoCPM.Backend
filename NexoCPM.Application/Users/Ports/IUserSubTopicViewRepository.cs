using NexoCPM.Domain.Users.Entities;

namespace NexoCPM.Application.Users.Ports;

public interface IUserSubTopicViewRepository
{
    Task MarkAsViewedAsync(int userSyllabusUnitProgressId, int subTopicId);
    Task<bool> IsViewedAsync(int userSyllabusUnitProgressId, int subTopicId);
    Task<UserSubTopicView> ToggleCompletionAsync(int userSyllabusUnitProgressId, int subTopicId);
}
