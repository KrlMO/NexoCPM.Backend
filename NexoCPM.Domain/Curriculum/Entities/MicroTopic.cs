using NexoCPM.Domain.Common;
using NexoCPM.Domain.Evaluations.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Curriculum.Entities
{
    public class MicroTopic : AuditableEntity
    {
        public int Id { get; private set; }
        public int SubTopicId { get; private set; }
        public string Code { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public int OrderIndex { get; private set; }
        public bool IsActive { get; private set; } = true;
        public bool IsDeleted { get; private set; } = false;

        public SubTopic SubTopic { get; private set; } = null!;

        public MicroTopic() { }

    }
}
