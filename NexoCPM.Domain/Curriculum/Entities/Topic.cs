using NexoCPM.Domain.Common;
using NexoCPM.Domain.Evaluations.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Curriculum.Entities
{
    public class Topic : AuditableEntity
    {
        public long Id { get; set; }
        public long SyllabusTopicId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
        public bool IsActive { get; set; } = true;

        public ICollection<QuestionTopic> QuestionTopics { get; set; } = new HashSet<QuestionTopic>();
        public ICollection<Subtopic> Subtopics { get; set; } = new HashSet<Subtopic>();

        public SyllabusTopic SyllabusTopic { get; set; } = null!;

        public Topic(){ }
    }
}
