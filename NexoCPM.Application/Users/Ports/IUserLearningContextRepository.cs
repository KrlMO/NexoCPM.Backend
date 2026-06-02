using NexoCPM.Application.Commons.Dtos;
using NexoCPM.Application.Users.Dtos;
using NexoCPM.Domain.Users.Entities;

namespace NexoCPM.Application.Users.Ports
{
    public interface IUserLearningContextRepository
    {
        Task<UserLearningContext?> GetByIdAsync(int id);
        Task<UserLearningContext?> GetByUserAndSyllabusSlugAsync(int userId, string syllabusSlug);
        Task<UserLearningContext?> GetByUserAndSyllabusSlugTrackedAsync(int userId, string syllabusSlug);
        Task<UserLearningContext> AddAsync(UserLearningContext userLearningContext);
        Task<PaginatedResult<UserLearningContext>> GetByUserIdPagedAsync(int userId, string? searchTerm, string sortOrder, int page, int pageSize);
        Task<Dictionary<int, ProgressSummary>> GetProgressSummariesAsync(int[] userSyllabusProgressIds, int userId);
        Task<UserSyllabusDetailData?> GetDetailAsync(int userId, int userLearningContextId, string syllabusSlug);
        Task<int?> GetProgressIdAsync(int userId, int userLearningContextId);
        Task SaveChangesAsync();
    }

    public class ProgressSummary
    {
        public int TotalSubTopics { get; set; }
        public int ViewedSubTopics { get; set; }
    }
}
