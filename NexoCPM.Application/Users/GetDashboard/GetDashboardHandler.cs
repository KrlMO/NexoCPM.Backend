using MediatR;
using NexoCPM.Application.Auth.Ports;
using NexoCPM.Application.Users.Ports;
using System.Security.Claims;

namespace NexoCPM.Application.Users.GetDashboard
{
    public class GetDashboardHandler : IRequestHandler<GetDashboardQuery, GetDashboardResponse>
    {
        private readonly IJwtService _jwtService;
        private readonly IUserLeaderboardRepository _leaderboardRepository;
        private readonly IUserProgressRepository _progressRepository;

        public GetDashboardHandler(
            IJwtService jwtService,
            IUserLeaderboardRepository leaderboardRepository,
            IUserProgressRepository progressRepository)
        {
            _jwtService = jwtService;
            _leaderboardRepository = leaderboardRepository;
            _progressRepository = progressRepository;
        }

        public async Task<GetDashboardResponse> Handle(GetDashboardQuery request, CancellationToken cancellationToken)
        {
            var principal = _jwtService.DecodeToken(request.jwt);

            var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
                throw new UnauthorizedAccessException("Token inválido");

            var userIdInt = int.Parse(userId);

            var leaderboard = await _leaderboardRepository.GetByUserIdAsync(userIdInt);
            var activeSyllabus = await _progressRepository.GetActiveSyllabusProgressAsync(userIdInt);
            var overallProgress = await _progressRepository.GetOverallProgressPercentageAsync(userIdInt);

            var totalStars = leaderboard?.TotalStars ?? 0;
            var ranking = leaderboard is not null
                ? await _leaderboardRepository.GetRankByTotalStarsAsync(totalStars)
                : 0;

            return new GetDashboardResponse
            {
                TotalStars = totalStars,
                Ranking = ranking,
                TotalSimulations = 0,
                TotalTests = 0,
                ProgressPercentage = overallProgress,
                ActiveSyllabus = activeSyllabus,
                TotalSyllabus = activeSyllabus.Count,
                UserHasInfo = activeSyllabus.Count > 0
            };
        }
    }
}
