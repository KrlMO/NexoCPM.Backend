using MediatR;
using NexoCPM.Application.Evaluations.Ports;
using NexoCPM.Application.Users.Dtos;
using NexoCPM.Application.Users.Ports;

namespace NexoCPM.Application.Users.Queries.GetDashboard
{
    public class GetDashboardHandler : IRequestHandler<GetDashboardQuery, GetDashboardResponse>
    {
        private readonly IUserLeaderboardRepository _leaderboardRepository;
        private readonly IUserProgressRepository _progressRepository;
        private readonly IAssessmentAttemptRepository _assessmentAttemptRepository;

        public GetDashboardHandler(
            IUserLeaderboardRepository leaderboardRepository,
            IUserProgressRepository progressRepository,
            IAssessmentAttemptRepository assessmentAttemptRepository)
        {
            _leaderboardRepository = leaderboardRepository;
            _progressRepository = progressRepository;
            _assessmentAttemptRepository = assessmentAttemptRepository;
        }

        public async Task<GetDashboardResponse> Handle(GetDashboardQuery request, CancellationToken cancellationToken)
        {
            var userIdInt = request.userId;

            var leaderboard = await _leaderboardRepository.GetByUserIdAsync(userIdInt);
            var activeSyllabus = await _progressRepository.GetActiveSyllabusProgressAsync(userIdInt);
            var overallProgress = await _progressRepository.GetOverallProgressPercentageAsync(userIdInt);
            var totalTests = await _progressRepository.GetTestCountAsync(userIdInt);
            var totalSimulations = await _progressRepository.GetSimulationCountAsync(userIdInt);

            var totalStars = leaderboard?.TotalStars ?? 0;
            var ranking = leaderboard is not null
                ? await _leaderboardRepository.GetRankByTotalStarsAsync(totalStars)
                : 0;

            var lastSyllabus = activeSyllabus.FirstOrDefault();
            var lastSimulations = await _assessmentAttemptRepository.GetLastSimulationsAsync(userIdInt, 2);
            var failedSubtopics = await _assessmentAttemptRepository.GetTopFailedSubtopicsAsync(userIdInt, 3);
            var recomendations = failedSubtopics
                .Select(st => $"Refuerza: \"{st}\"")
                .ToList();

            return new GetDashboardResponse
            {
                TotalStars = totalStars,
                Ranking = ranking,
                TotalSimulations = totalSimulations,
                TotalTests = totalTests,
                ProgressPercentage = overallProgress,
                ActiveSyllabus = activeSyllabus,
                TotalSyllabus = activeSyllabus.Count,
                UserHasInfo = activeSyllabus.Count > 0,
                LastSyllabus = lastSyllabus,
                LastSimulations = lastSimulations,
                Recomendations = recomendations,
            };
        }
    }
}
