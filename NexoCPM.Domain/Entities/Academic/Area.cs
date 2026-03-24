using NexoCPM.Domain.Common;
using NexoCPM.Domain.Entities.Evaluations;
using NexoCPM.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Academic
{
    public class Area : AuditableEntity
    {
        public long Id { get; set; }
        public long EducationLevelId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public ICollection<UserProgress> UserProgresses { get; set; } = new HashSet<UserProgress>();
        public ICollection<Assessment> Assessments { get; set; } = new HashSet<Assessment>();

        public required EducationLevel EducationLevel { get; set; }

        public Area() { }

    }
}
