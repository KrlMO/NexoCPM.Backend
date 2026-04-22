using NexoCPM.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Evaluations.Entities
{
    public class Option
    {
        public int Id { get; private set; }
        public int QuestionId { get; private set; }
        public string Text { get; private set; } = string.Empty;
        public bool IsCorrect { get; private set; }

        public ICollection<AssessmentAttemptQuestion> AssessmentAttemptQuestions { get; private set; } = new HashSet<AssessmentAttemptQuestion>();

        public Question Question { get; private set; } = null!;

        public Option() { }
    }
}
