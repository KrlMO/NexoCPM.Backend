using NexoCPM.Domain.Curriculum.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Evaluations.Entities
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
