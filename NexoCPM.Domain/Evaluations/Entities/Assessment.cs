using NexoCPM.Domain.Curriculum.Entities;
using NexoCPM.Domain.Evaluations.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Evaluations.Entities
{
    public class Assessment
    {
        public int Id { get; private set; }
        public string Code { get; private set; } = string.Empty;
        public string Title { get; private set; } = string.Empty;
        public AssessmentType Type { get; private set; }
        public AssessmentScope Scope { get; private set; }
        public int? TargetId { get; private set; } = null;
        public bool IsActive { get; private set; }
        public int? TimeLimitSeconds { get; private set; } = null;
        public int NumberQuestions { get; private set; }
        public int? MaxAttempts { get; private set; } = null;

        public ICollection<AssessmentAttempt> AssessmentAttempts { get; private set; } = new List<AssessmentAttempt>();

        public Assessment() { }
    }
}
