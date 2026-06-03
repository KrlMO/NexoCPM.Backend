using MediatR;
using NexoCPM.Application.Evaluations.Ports;

namespace NexoCPM.Application.Evaluations.Queries.GetSimulationHistory
{
    public class GetSimulationHistoryHandler : IRequestHandler<GetSimulationHistoryQuery, GetSimulationHistoryResponse>
    {
        private readonly IAssessmentAttemptRepository _assessmentAttemptRepository;

        public GetSimulationHistoryHandler(IAssessmentAttemptRepository assessmentAttemptRepository)
        {
            _assessmentAttemptRepository = assessmentAttemptRepository;
        }

        public async Task<GetSimulationHistoryResponse> Handle(GetSimulationHistoryQuery request, CancellationToken cancellationToken)
        {
            var history = await _assessmentAttemptRepository.GetSimulationHistoryAsync(
                request.UserId, request.Page, request.PageSize);

            return new GetSimulationHistoryResponse { History = history };
        }
    }
}
