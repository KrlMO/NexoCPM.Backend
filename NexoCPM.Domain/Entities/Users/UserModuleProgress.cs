using NexoCPM.Domain.Entities.Academic;
using NexoCPM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Users
{
    public class UserModuleProgress
    {
        public long UserId { get; set; }
        public long ModuleId { get; set; }
        public UserModuleProgressStatus Status { get; set; }
        public double Score { get; set; }
        public int Attempts { get; set; }
        public DateTime LastAttemptAt { get; set; }

        public required User User { get; set; }
        public required Module Module { get; set; }

        public UserModuleProgress() { }
    }
}
