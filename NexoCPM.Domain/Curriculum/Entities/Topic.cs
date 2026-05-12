using NexoCPM.Domain.Common;
using NexoCPM.Domain.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Curriculum.Entities
{
    public class Topic : AuditableEntity
    {
        public int Id { get; private set; }
        public string Code { get; private set; } = string.Empty;
        public int SyllabusUnitId { get; private set; }
        public string Slug { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public int OrderIndex { get; private set; }
        public bool IsDeleted { get; private set; } = false;
        public bool IsActive { get; private set; } = true;

        public ICollection<SubTopic> SubTopics { get; private set; } = new List<SubTopic>();

        public SyllabusUnit SyllabusUnit { get; private set; } = null!;

        public Topic() { }

        public Topic(string code, string slug, string description, int orderIndex, int syllabusUnitId)
        {
            Code = code;
            Slug = slug;
            Description = description;
            OrderIndex = orderIndex;
            SyllabusUnitId = syllabusUnitId;
            IsActive = true;
            IsDeleted = false;
        }
    }
}
