using NexoCPM.Domain.Entities.Academic;
using NexoCPM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Users
{
    public class UserProgress
    {
        public long UserId { get; set; }
        public long AreaId { get; set; }
        public double ProgressPercentage { get; set; }
        public DateTime LastAccess { get; set; }
        public UserProgressStatus status { get; set; }
        public required User User { get; set; }
        public required Area Area { get; set; }

        public UserProgress() { }
    }
}
