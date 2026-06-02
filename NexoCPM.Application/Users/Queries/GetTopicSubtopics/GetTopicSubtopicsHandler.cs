using MediatR;
using NexoCPM.Application.Curriculum.Ports;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Users.Entities;

namespace NexoCPM.Application.Users.Queries.GetTopicSubtopics
{
    public class GetTopicSubtopicsHandler : IRequestHandler<GetTopicSubtopicsQuery, GetTopicSubtopicsResponse>
    {
        private readonly IUserLearningContextRepository _userLearningContextRepository;
        private readonly ISyllabusUnitRepository _syllabusUnitRepository;

        public GetTopicSubtopicsHandler(
            IUserLearningContextRepository userLearningContextRepository,
            ISyllabusUnitRepository syllabusUnitRepository)
        {
            _userLearningContextRepository = userLearningContextRepository;
            _syllabusUnitRepository = syllabusUnitRepository;
        }

        public async Task<GetTopicSubtopicsResponse> Handle(GetTopicSubtopicsQuery request, CancellationToken cancellationToken)
        {
            var progressId = await _userLearningContextRepository.GetProgressIdAsync(request.userId, request.userLearningContextId);
            if (progressId is null)
                throw new KeyNotFoundException("Contexto de aprendizaje no encontrado.");

            var subTopics = await _syllabusUnitRepository.GetTopicSubtopicsAsync(request.topicId, progressId.Value, request.userId);
            return new GetTopicSubtopicsResponse { subTopics = subTopics };
        }
    }
}
