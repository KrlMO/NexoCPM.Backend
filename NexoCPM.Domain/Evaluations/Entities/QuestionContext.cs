using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Evaluations.Entities
{
    public class QuestionContext
    {
        public long Id { get; private set; }
        public string? Code { get; private set; }
        public string? Url { get; private set; }
        public string ContextText { get; private set; } = string.Empty;
        public ICollection<Question> Questions { get; private set; } = new HashSet<Question>();
        public QuestionContext() { }
    }
}
