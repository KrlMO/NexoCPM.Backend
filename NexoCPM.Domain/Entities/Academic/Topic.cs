using NexoCPM.Domain.Common;
using NexoCPM.Domain.Entities.Evaluations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Academic
{
    public class Topic : AuditableEntity
    {
        public long Id { get; set; }
        public long ModuleId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }

        public ICollection<QuestionTopic> QuestionTopics { get; set; } = new List<QuestionTopic>();

        public required Module Module { get; set; }

        public Topic() { }
    }
}
