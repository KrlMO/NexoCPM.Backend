using NexoCPM.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Evaluations.Entities
{
    public class AssesmentAttempt
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long AssessmentId { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }

        public ICollection<AssesmentAttemptQuestion> AssesmentAttemptQuestions { get; set; } = new List<AssesmentAttemptQuestion>();

        public required User User { get; set; }
        public required Assesment Assessment { get; set; }

        public AssesmentAttempt(){ }
    }
}
