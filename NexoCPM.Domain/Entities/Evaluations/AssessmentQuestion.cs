using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Evaluations
{
    public class AssessmentQuestion
    {
        public long AssessmentId { get; set; }
        public long QuestionId { get; set; }

        public required Assessment Assessment { get; set; }
        public required Question Question { get; set; }

        public AssessmentQuestion() { }
    }
}
