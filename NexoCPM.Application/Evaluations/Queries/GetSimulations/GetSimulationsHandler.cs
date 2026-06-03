using MediatR;
using NexoCPM.Application.Evaluations.Ports;

namespace NexoCPM.Application.Evaluations.Queries.GetSimulations
{
    public class GetSimulationsHandler : IRequestHandler<GetSimulationsQuery, GetSimulationsResponse>
    {
        private readonly IAssessmentRepository _assessmentRepository;

        public GetSimulationsHandler(IAssessmentRepository assessmentRepository)
        {
            _assessmentRepository = assessmentRepository;
        }

        public async Task<GetSimulationsResponse> Handle(GetSimulationsQuery request, CancellationToken cancellationToken)
        {
            var simulations = await _assessmentRepository.GetSimulationsPagedAsync(
                request.searchTerm,
                request.page,
                request.pageSize);

            return new GetSimulationsResponse { Simulations = simulations };
        }
    }
}
