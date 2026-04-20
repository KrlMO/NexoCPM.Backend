using NexoCPM.Domain.Curriculum.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Evaluations.Entities
{
    public class QuestionSubTopic
    {
        public long QuestionId { get; set; }
        public long SubTopicId { get; set; }

        public Question Question { get; set; } = null!;
        public Subtopic Subtopic { get; set; } = null!;

        public QuestionSubTopic() { }
    }
}
