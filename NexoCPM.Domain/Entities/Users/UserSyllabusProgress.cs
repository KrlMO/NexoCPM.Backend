using NexoCPM.Domain.Common;
using NexoCPM.Domain.Entities.Curriculum;
using NexoCPM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Users
{
    public class UserSyllabusProgress : AuditableEntity
    {
        public long UserId { get; set; }
        public long AreaId { get; set; }
        public double ProgressPercentage { get; set; }
        public DateTime LastAccess { get; set; }
        public UserProgressStatus status { get; set; }

        public required User User { get; set; }
        public required Syllabus Syllabus { get; set; }

        public UserSyllabusProgress() { }
    }
}
