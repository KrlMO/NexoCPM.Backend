using NexoCPM.Domain.Users.Entities;

namespace NexoCPM.Application.Users.Ports;

public interface IUserSyllabusProgressRepository
{
    Task<UserSyllabusProgress?> GetByLearningContextAsync(int userLearningContextId);
    Task UpdateAsync(UserSyllabusProgress progress);
}
