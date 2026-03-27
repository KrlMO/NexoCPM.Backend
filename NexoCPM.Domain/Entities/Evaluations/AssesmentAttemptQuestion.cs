using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Evaluations
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
