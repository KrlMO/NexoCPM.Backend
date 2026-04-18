using NexoCPM.Domain.Common;
using NexoCPM.Domain.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Curriculum.Entities
{
    public class SyllabusContext : AuditableEntity
    {
        public int SyllabusId { get; set; }
        public long EducationContextId { get; set; }

        public required Syllabus Syllabus { get; set; }
        public required EducationContext EducationContext { get; set; }

        public SyllabusContext() { }
    }
}
