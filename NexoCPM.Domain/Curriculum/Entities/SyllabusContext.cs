using NexoCPM.Domain.Common;
using NexoCPM.Domain.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Curriculum.Entities
{
    public class SyllabusContext : AuditableEntity
    {
        public int SyllabusId { get; private set; }
        public int EducationContextId { get; private set; }

        public Syllabus Syllabus { get; private set; } = null!;
        public EducationContext EducationContext { get; private set; } = null!;
        public SyllabusContext() { }
    }
}
