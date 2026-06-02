using NexoCPM.Application.Users.Dtos;

namespace NexoCPM.Application.Curriculum.Ports
{
    public interface ISyllabusUnitRepository
    {
        Task<UserSyllabusUnitData?> GetUnitDetailAsync(int syllabusUnitId, int userSyllabusProgressId, int userId);
        Task<List<UserSyllabusTopicData>> GetUnitTopicsAsync(int syllabusUnitId, int userSyllabusProgressId, int userId);
        Task<List<UserSyllabusSubtopicData>> GetTopicSubtopicsAsync(int topicId, int userSyllabusProgressId, int userId);
    }
}
