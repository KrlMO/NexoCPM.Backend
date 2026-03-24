using NexoCPM.Domain.Entities.Evaluations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Users
{
    public class UserAssessmentResult
    {
        public long UserId { get; set; }
        public long AssessmentId { get; set; }
        public double Score { get; set; }
        public bool Passed { get; set; }
        public DateTime TakenAt { get; set; }

        public required User User { get; set; }
        public required Assessment Assessment { get; set; }

        public UserAssessmentResult() { }

    }
}
