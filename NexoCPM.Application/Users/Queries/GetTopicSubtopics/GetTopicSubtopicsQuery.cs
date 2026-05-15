using MediatR;

namespace NexoCPM.Application.Users.Queries.GetTopicSubtopics
{
    public record GetTopicSubtopicsQuery(int userId, int userLearningContextId, int topicId) : IRequest<GetTopicSubtopicsResponse>;
}
