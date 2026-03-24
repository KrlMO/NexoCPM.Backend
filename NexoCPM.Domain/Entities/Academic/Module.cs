using NexoCPM.Domain.Common;
using NexoCPM.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Academic
{
    public class Module : AuditableEntity
    {
        public long Id { get; set; }
        public long AreaId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
        public bool IsActive { get; set; }

        public ICollection<UserModuleProgress> UserModuleProgress { get; set; } = new HashSet<UserModuleProgress>();
        public ICollection<Topic> Topics { get; set; } = new List<Topic>();

        public required Area Area { get; set; }

        public Module() { }

    }
}
