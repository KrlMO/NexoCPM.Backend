using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Evaluations.Entities
{
    public class AssesmentAttemptQuestion
    {
        public long AssesmentAttemptId { get; set; }
        public long QuestionId { get; set; }

        public required AssesmentAttempt AssesmentAttempt { get; set; }
        public required Question Question { get; set; }

        public AssesmentAttemptQuestion() { }
    }
}
