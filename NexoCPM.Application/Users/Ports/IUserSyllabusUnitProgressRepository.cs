using NexoCPM.Domain.Users.Entities;

namespace NexoCPM.Application.Users.Ports;

public interface IUserSyllabusUnitProgressRepository
{
    Task<UserSyllabusUnitProgress?> GetByProgressAndUnitAsync(int userSyllabusProgressId, int syllabusUnitId);
    Task<UserSyllabusUnitProgress> AddAsync(UserSyllabusUnitProgress progress);
    Task UpdateAsync(UserSyllabusUnitProgress progress);
}
