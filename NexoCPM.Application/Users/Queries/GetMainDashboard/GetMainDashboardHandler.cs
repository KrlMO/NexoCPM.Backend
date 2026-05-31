using MediatR;
using NexoCPM.Application.Evaluations.Ports;
using NexoCPM.Application.Users.Dtos;
using NexoCPM.Application.Users.Ports;

namespace NexoCPM.Application.Users.Queries.GetMainDashboard
{
    public class GetMainDashboardHandler : IRequestHandler<GetMainDashboardQuery, GetMainDashboardResponse>
    {
        private readonly IUserLeaderboardRepository _leaderboardRepository;
        private readonly IUserProgressRepository _progressRepository;
        private readonly IAssessmentAttemptRepository _assessmentAttemptRepository;

        public GetMainDashboardHandler(
            IUserLeaderboardRepository leaderboardRepository,
            IUserProgressRepository progressRepository,
            IAssessmentAttemptRepository assessmentAttemptRepository)
        {
            _leaderboardRepository = leaderboardRepository;
            _progressRepository = progressRepository;
            _assessmentAttemptRepository = assessmentAttemptRepository;
        }

        public async Task<GetMainDashboardResponse> Handle(GetMainDashboardQuery request, CancellationToken cancellationToken)
        {
            var userId = request.UserId;

            var leaderboard = await _leaderboardRepository.GetByUserIdAsync(userId);
            var overallProgress = await _progressRepository.GetOverallProgressPercentageAsync(userId);
            var totalTests = await _progressRepository.GetTestCountAsync(userId);
            var totalSimulations = await _progressRepository.GetSimulationCountAsync(userId);

            var totalStars = leaderboard?.TotalStars ?? 0;
            var ranking = leaderboard is not null
                ? await _leaderboardRepository.GetRankByTotalStarsAsync(totalStars)
                : 0;

            var syllabiProgress = await _progressRepository.GetSyllabiProgressAsync(userId);
            var lastTests = await _assessmentAttemptRepository.GetLastTestChartDataAsync(userId, 5);
            var lastSimulations = await _assessmentAttemptRepository.GetLastSimulationChartDataAsync(userId, 5);

            return new GetMainDashboardResponse
            {
                StatGridData = new StatGridData
                {
                    TotalStars = totalStars,
                    Ranking = ranking,
                    TotalSimulations = totalSimulations,
                    TotalTests = totalTests,
                    ProgressPercentage = overallProgress
                },
                SyllabiProgress = syllabiProgress,
                LastTests = lastTests,
                LastSimulations = lastSimulations
            };
        }
    }
}
