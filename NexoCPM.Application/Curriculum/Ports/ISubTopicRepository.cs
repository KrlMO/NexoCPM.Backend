using NexoCPM.Application.Commons.Dtos;
using NexoCPM.Application.Curriculum.Dtos;

namespace NexoCPM.Application.Curriculum.Ports
{
    public interface ISubTopicRepository
    {
        Task<PaginatedResult<SubTopicDetailDto>> GetSubTopicDetailPagedAsync(string subtopicSlug, int page, int pageSize, int userId, int userLearningContextId);
    }
}
