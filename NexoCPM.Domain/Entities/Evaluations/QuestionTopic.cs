using NexoCPM.Domain.Entities.Academic;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Evaluations
{
    public class QuestionTopic
    {
        public long QuestionId { get; set; }
        public long TopicId { get; set; }

        public required Question Question { get; set; }
        public required Topic Topic { get; set; }

        public QuestionTopic() { }
    }
}
