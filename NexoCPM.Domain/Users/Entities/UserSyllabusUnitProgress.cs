using NexoCPM.Domain.Common;
using NexoCPM.Domain.Curriculum.Entities;
using NexoCPM.Domain.Users.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Users.Entities
{
    public class UserSyllabusUnitProgress : AuditableEntity
    {
        public long UserId { get; set; }
        public long SyllabusUnitId { get; set; }
        public UserModuleProgressStatus Status { get; set; }
        public double Score { get; set; }
        public int Attempts { get; set; }
        public DateTime LastAttemptAt { get; set; }

        public required User User { get; set; }
        public required SyllabusUnit SyllabusUnit { get; set; }

        public UserSyllabusUnitProgress() { }
    }
}
