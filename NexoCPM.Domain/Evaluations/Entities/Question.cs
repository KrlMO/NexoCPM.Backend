using NexoCPM.Domain.Common;
using NexoCPM.Domain.Curriculum.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Evaluations.Entities
{
    public class Question : AuditableEntity
    {
        public int Id { get; private set; }
        public string Code { get; private set; } = string.Empty;
        public string? Explanation { get; private set; } = null;
        public bool IsActive { get; private set; } = true;
        public bool IsDeleted { get; private set; } = false;
        public int TotalAttempts { get; private set; } = 0;
        public int TotalCorrect { get; private set; } = 0;
        public int SubTopicId { get; private set; }
        public string Statement { get; private set; } = string.Empty;

        public ICollection<AssessmentAttemptQuestion> AssessmentAttemptQuestions { get; private set; } = new HashSet<AssessmentAttemptQuestion>();
        public ICollection<Option> Options { get; private set; } = new HashSet<Option>();
        public ICollection<QuestionContext> QuestionContexts { get; private set; } = new HashSet<QuestionContext>();

        public SubTopic SubTopic { get; private set; } = null!;

        public Question() { }

        public double GetDifficulty()
        {
            if (TotalAttempts == 0) return 0;
            return 1.0 - ((double)TotalCorrect / TotalAttempts);
        }
    }
}
