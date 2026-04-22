using NexoCPM.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Evaluations.Entities
{
    public class AssessmentAttempt
    {
        public int Id { get; private set; }
        public int AssessmentId { get; private set; }
        public int UserLearningContextId { get; private set; }
        public DateTime StartedAt { get; private set; } = DateTime.Now;
        public DateTime FinishedAt { get; private set; }
        public int Score { get; private set; }
        public int TotalQuestions { get; private set; }
        public int CorrectAnswers { get; private set; }

        public ICollection<AssessmentAttemptQuestion> AssessmentAttemptQuestions { get; private set; } = new List<AssessmentAttemptQuestion>();

        public Assessment Assessment { get; private set; } = null!;
        public UserLearningContext UserLearningContext { get; private set; } = null!;

        public AssessmentAttempt(){ }
    }
}
