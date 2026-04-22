using NexoCPM.Domain.Resources.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Users.Entities
{
    public class UserResourceView
    {
        public int UserId { get; private set; }
        public int ResourceId { get; private set; }
        public DateTime ViewedAt { get; private set; } = DateTime.Now;

        public User User { get; private set; } = null!;
        public Resource Resource { get; private set; } = null!;

        public UserResourceView() { }
    }
}
