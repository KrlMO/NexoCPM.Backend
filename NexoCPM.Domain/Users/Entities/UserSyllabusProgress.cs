using NexoCPM.Domain.Common;
using NexoCPM.Domain.Curriculum.Entities;
using NexoCPM.Domain.Users.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Users.Entities
{
    public class UserSyllabusProgress : AuditableEntity
    {
        public long UserId { get; set; }
        public long SyllabusId { get; set; }
        public double ProgressPercentage { get; set; }
        public DateTime LastAccess { get; set; }
        public UserProgressStatus Status { get; set; }

        public required User User { get; set; }
        public required Syllabus Syllabus { get; set; }

        public UserSyllabusProgress() { }
    }
}
