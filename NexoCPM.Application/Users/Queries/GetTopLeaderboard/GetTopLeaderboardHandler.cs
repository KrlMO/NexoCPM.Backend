using MediatR;
using NexoCPM.Application.Users.Ports;

namespace NexoCPM.Application.Users.Queries.GetTopLeaderboard
{
    public class GetTopLeaderboardHandler : IRequestHandler<GetTopLeaderboardQuery, GetTopLeaderboardResponse>
    {
        private readonly IUserLeaderboardRepository _leaderboardRepository;

        public GetTopLeaderboardHandler(IUserLeaderboardRepository leaderboardRepository)
        {
            _leaderboardRepository = leaderboardRepository;
        }

        public async Task<GetTopLeaderboardResponse> Handle(GetTopLeaderboardQuery request, CancellationToken cancellationToken)
        {
            var leaderboards = await _leaderboardRepository.GetTopUsersAsync(request.Count);

            var entries = leaderboards
                .Select((ul, index) => new LeaderboardEntry
                {
                    Rank = index + 1,
                    UserId = ul.UserId,
                    Code = ul.User.Code,
                    FirstName = ul.User.FirstName,
                    LastName = ul.User.LastName,
                    UserName = ul.User.UserName,
                    AvatarUrl = ul.User.AvatarUrl,
                    TotalStars = ul.TotalStars
                })
                .ToList();

            return new GetTopLeaderboardResponse
            {
                Entries = entries
            };
        }
    }
}
