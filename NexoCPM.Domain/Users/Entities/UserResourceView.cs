using NexoCPM.Domain.Resources.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Users.Entities
{
    public class UserResourceView
    {
        public long UserId { get; set; }
        public long ResourceId { get; set; }
        public DateTime ViewedAt { get; set; }
        public double ResourcesViewedCount { get; set; } = 0;

        public required User User { get; set; }
        public required Resource Resource { get; set; }

        public UserResourceView() { }
    }
}
