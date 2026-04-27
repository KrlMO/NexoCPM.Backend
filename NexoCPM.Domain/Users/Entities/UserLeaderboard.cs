using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Users.Entities
{
    public class UserLeaderboard
    {
        public int UserId { get; private set; }
        public int TotalStars { get; private set; } = 0;
        public DateTime LastUpdated { get; private set; } = DateTime.MinValue;

        public User User { get; private set; } = null!;

        public UserLeaderboard() { }
    }
}
