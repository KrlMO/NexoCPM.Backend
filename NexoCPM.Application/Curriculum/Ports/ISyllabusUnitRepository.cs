using NexoCPM.Application.Users.Dtos;

namespace NexoCPM.Application.Curriculum.Ports
{
    public interface ISyllabusUnitRepository
    {
        Task<UserSyllabusUnitData?> GetUnitDetailAsync(int syllabusUnitId, int userSyllabusProgressId);
    }
}
