using MediatR;
using NexoCPM.Application.Evaluations.Ports;
using NexoCPM.Application.Users.Ports;

namespace NexoCPM.Application.Users.Queries.GetDashboardSyllabusDetails
{
    public class GetDashboardSyllabusDetailsHandler
        : IRequestHandler<GetDashboardSyllabusDetailsQuery, GetDashboardSyllabusDetailsResponse>
    {
        private readonly IUserProgressRepository _progressRepository;
        private readonly IAssessmentAttemptRepository _assessmentAttemptRepository;

        public GetDashboardSyllabusDetailsHandler(
            IUserProgressRepository progressRepository,
            IAssessmentAttemptRepository assessmentAttemptRepository)
        {
            _progressRepository = progressRepository;
            _assessmentAttemptRepository = assessmentAttemptRepository;
        }

        public async Task<GetDashboardSyllabusDetailsResponse> Handle(
            GetDashboardSyllabusDetailsQuery request, CancellationToken cancellationToken)
        {
            var units = await _progressRepository.GetUnitProgressAsync(request.UserLearningContextId);
            var recommendations = await _assessmentAttemptRepository
                .GetFailedSubtopicsAsync(request.UserLearningContextId, 5);

            return new GetDashboardSyllabusDetailsResponse
            {
                Units = units,
                Recommendations = recommendations
            };
        }
    }
}
