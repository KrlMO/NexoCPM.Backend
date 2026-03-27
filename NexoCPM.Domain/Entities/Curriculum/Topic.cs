using NexoCPM.Domain.Common;
using NexoCPM.Domain.Entities.Evaluations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Curriculum
{
    public class Topic : AuditableEntity
    {
        public long Id { get; set; }
        public long SyllabusTopicId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
        public bool IsActive { get; set; }

        public ICollection<QuestionTopic> QuestionTopics { get; set; } = new HashSet<QuestionTopic>();

        public required SyllabusTopic SyllabusTopic { get; set; }

        public Topic(){ }
    }
}
