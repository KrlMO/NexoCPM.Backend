using MediatR;
using NexoCPM.Application.Curriculum.Ports;
using NexoCPM.Application.Users.Ports;

namespace NexoCPM.Application.Users.Queries.GetUnitTopics
{
    public class GetUnitTopicsHandler : IRequestHandler<GetUnitTopicsQuery, GetUnitTopicsResponse>
    {
        private readonly IUserLearningContextRepository _userLearningContextRepository;
        private readonly ISyllabusUnitRepository _syllabusUnitRepository;

        public GetUnitTopicsHandler(
            IUserLearningContextRepository userLearningContextRepository,
            ISyllabusUnitRepository syllabusUnitRepository)
        {
            _userLearningContextRepository = userLearningContextRepository;
            _syllabusUnitRepository = syllabusUnitRepository;
        }

        public async Task<GetUnitTopicsResponse> Handle(GetUnitTopicsQuery request, CancellationToken cancellationToken)
        {
            var progressId = await _userLearningContextRepository.GetProgressIdAsync(request.userId, request.userLearningContextId);
            if (progressId is null)
                throw new KeyNotFoundException("Contexto de aprendizaje no encontrado.");

            var topics = await _syllabusUnitRepository.GetUnitTopicsAsync(request.unitId, progressId.Value);
            return new GetUnitTopicsResponse { topics = topics };
        }
    }
}
