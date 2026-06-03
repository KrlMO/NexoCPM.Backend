using System.Collections.Generic;

namespace NexoCPM.Application.Users.Queries.GetTopLeaderboard
{
    public class GetTopLeaderboardResponse
    {
        public List<LeaderboardEntry> Entries { get; set; } = new();
    }

    public class LeaderboardEntry
    {
        public int Rank { get; set; }
        public int UserId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string? AvatarUrl { get; set; }
        public int TotalStars { get; set; }
    }
}
