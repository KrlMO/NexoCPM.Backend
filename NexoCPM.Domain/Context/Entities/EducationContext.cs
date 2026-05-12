using NexoCPM.Domain.Common;
using NexoCPM.Domain.Curriculum.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Context.Entities
{
    public class EducationContext : AuditableEntity
    {
        public int Id { get; private set; }
        public int LevelId { get; private set; }
        public int SpecializationId { get; private set; }
        public bool IsActive { get; private set; } = true;
        public bool IsDeleted { get; private set; } = false;

        public ICollection<SyllabusContext> SyllabusContexts { get; private set; } = new HashSet<SyllabusContext>();

        public Level Level { get; private set; } = null!;
        public Specialization? Specialization { get; private set; }

        public EducationContext() { }
    }
}
