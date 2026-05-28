using MediatR;
using NexoCPM.Application.Evaluations.Ports;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Evaluations.Enums;

namespace NexoCPM.Application.Users.Queries.GetUserSyllabusDetail
{
    public class GetUserSyllabusDetailHandler : IRequestHandler<GetUserSyllabusDetailQuery, GetUserSyllabusDetailResponse>
    {
        private readonly IUserLearningContextRepository _repository;
        private readonly IAssessmentRepository _assessmentRepository;

        public GetUserSyllabusDetailHandler(
            IUserLearningContextRepository repository, IAssessmentRepository assessmentRepository   )
        {
            _repository = repository;
            _assessmentRepository = assessmentRepository;
        }

        public async Task<GetUserSyllabusDetailResponse> Handle(GetUserSyllabusDetailQuery request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetDetailAsync(request.userId, request.userLearningContextId, request.syllabusSlug);

            if (data is null)
                throw new KeyNotFoundException("Temario no encontrado para este usuario.");

            var finalTest = await _assessmentRepository.GetAssessmentByTargetdAsync(data.Id, AssessmentScope.SYLLABUS, AssessmentType.KNOLEDGE);
            return new GetUserSyllabusDetailResponse { userSyllabus = data, FinalSyllabusTest = finalTest };
        }
    }
}
