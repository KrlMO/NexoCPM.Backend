using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Evaluations.Entities
{
    public class AssessmentAttemptQuestion
    {
        public int Id { get; private set; }
        public int AssessmentAttemptId { get; private set; }
        public int QuestionId { get; private set; }
        public int? SelectedOptionId { get; private set; } = null;
        public DateTime AnsweredAt { get; private set; } = DateTime.UtcNow;
        public int SecondsSpent { get; private set; }
        public int OrderIndex { get; private set; }

        public AssessmentAttempt AssessmentAttempt { get; private set; } = null!;
        public Question Question { get; private set; } = null!;
        public Option? SelectedOption { get; private set; } = null;

        public AssessmentAttemptQuestion() { }
    }
}
