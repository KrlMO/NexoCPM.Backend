using MediatR;

namespace NexoCPM.Application.Users.Queries.GetUnitTopics
{
    public record GetUnitTopicsQuery(int userId, int userLearningContextId, int unitId) : IRequest<GetUnitTopicsResponse>;
}
