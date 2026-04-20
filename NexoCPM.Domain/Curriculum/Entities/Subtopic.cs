using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Curriculum.Entities
{
    public class Subtopic
    {
        public long Id { get; set; }
        public long TopicId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
        public bool IsActive { get; set; } = true;

        public Topic Topic { get; set; } = null!;

        public Subtopic() { }

    }
}
