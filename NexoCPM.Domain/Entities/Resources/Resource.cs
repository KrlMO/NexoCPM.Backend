using NexoCPM.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Resources
{
    public class Resource
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public ICollection<UserResourceView> UserResourceViews { get; set; } = new HashSet<UserResourceView>();

        public Resource() { }

    }
}
