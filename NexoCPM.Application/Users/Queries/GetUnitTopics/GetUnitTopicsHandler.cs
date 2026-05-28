using MediatR;
using NexoCPM.Application.Curriculum.Ports;
using NexoCPM.Application.Evaluations.Ports;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Evaluations.Enums;

namespace NexoCPM.Application.Users.Queries.GetUnitTopics
{
    public class GetUnitTopicsHandler : IRequestHandler<GetUnitTopicsQuery, GetUnitTopicsResponse>
    {
        private readonly IUserLearningContextRepository _userLearningContextRepository;
        private readonly ISyllabusUnitRepository _syllabusUnitRepository;
        private readonly IAssessmentRepository _assessmentRepository;
        public GetUnitTopicsHandler(
            IUserLearningContextRepository userLearningContextRepository,
            ISyllabusUnitRepository syllabusUnitRepository,
            IAssessmentRepository assessmentRepository)
        {
            _userLearningContextRepository = userLearningContextRepository;
            _syllabusUnitRepository = syllabusUnitRepository;
            _assessmentRepository = assessmentRepository;
        }

        public async Task<GetUnitTopicsResponse> Handle(GetUnitTopicsQuery request, CancellationToken cancellationToken)
        {
            var progressId = await _userLearningContextRepository.GetProgressIdAsync(request.userId, request.userLearningContextId);
            if (progressId is null)
                throw new KeyNotFoundException("Contexto de aprendizaje no encontrado.");

            var topics = await _syllabusUnitRepository.GetUnitTopicsAsync(request.unitId, progressId.Value);
            var unitTest = await _assessmentRepository.GetAssessmentByTargetdAsync(request.unitId, AssessmentScope.UNIT, AssessmentType.KNOLEDGE);
            return new GetUnitTopicsResponse { Topics = topics, UnitTest = unitTest };
        }
    }
}
