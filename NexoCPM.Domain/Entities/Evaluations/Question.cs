using NexoCPM.Domain.Common;
using NexoCPM.Domain.Entities.Academic;
using NexoCPM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Evaluations
{
    public class Question : AuditableEntity
    {
        public long Id { get; set; }
        public long ModuleId { get; set; }
        public string Statament { get; set; } = string.Empty;
        public QuestionType QuestionType { get; set; }
        public bool IsActive { get; set; }

        public required Module Module { get; set; }

        public ICollection<AnswerOption> AnswerOptions { get; set; } = new HashSet<AnswerOption>();
        public ICollection<QuestionTopic> QuestionTopics { get; set; } = new HashSet<QuestionTopic>();
        public ICollection<AssessmentQuestion> AssessmentQuestions { get; set; } = new List<AssessmentQuestion>();

        public Question() { }
    }
}
