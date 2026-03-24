using NexoCPM.Domain.Entities.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Users
{
    public class UserResourceView
    {
        public long UserId { get; set; }
        public long ResourceId { get; set; }
        public DateTime ViewedAt { get; set; }

        public required User User { get; set; }
        public required Resource Resource { get; set; }

        public UserResourceView() { }
    }
}
