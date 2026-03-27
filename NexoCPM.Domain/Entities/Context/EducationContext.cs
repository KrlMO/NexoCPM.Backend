using NexoCPM.Domain.Common;
using NexoCPM.Domain.Entities.Curriculum;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Academic
{
    public class EducationContext : AuditableEntity
    {
        public long Id { get; set; }
        public long LevelId { get; set; }
        public long SpecializationId { get; set; }

        public ICollection<SyllabusContext> SyllabusContexts { get; set; } = new HashSet<SyllabusContext>();

        public required Level Level { get; set; }
        public Specialization? Specialization { get; set; }

        public EducationContext() { }
    }
}
