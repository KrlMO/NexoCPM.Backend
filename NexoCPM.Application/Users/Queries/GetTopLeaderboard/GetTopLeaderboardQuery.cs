using MediatR;

namespace NexoCPM.Application.Users.Queries.GetTopLeaderboard
{
    public record GetTopLeaderboardQuery(int Count = 20) : IRequest<GetTopLeaderboardResponse>;
}
