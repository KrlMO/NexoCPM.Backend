using NexoCPM.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Resources.Entities
{
    public class ResourceLike
    {
        public int UserId { get; private set; }
        public int ResourceId { get; private set; }

        public User User { get; private set; } = null!;
        public Resource Resource { get; private set; } = null!;

        public ResourceLike() { }
    }
}
