using NexoCPM.Domain.Common;
using NexoCPM.Domain.Curriculum.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Evaluations.Entities
{
    public class Question : AuditableEntity
    {
        public long Id { get; set; }
        public string Statement { get; set; } = string.Empty;
        public string? Explanation { get; set; }
        public bool IsActive { get; set; }
        public double Difficulty { get; set; }

        public ICollection<AnswerOption> AnswerOptions { get; set; } = new HashSet<AnswerOption>();
        public ICollection<QuestionTopic> QuestionTopics { get; set; } = new HashSet<QuestionTopic>();
        public ICollection<AssesmentAttemptQuestion> AssesmentAttemptQuestions { get; set; } = new HashSet<AssesmentAttemptQuestion>();
        

        public required Topic Topic { get; set; }

        public Question() { }
    }
}
