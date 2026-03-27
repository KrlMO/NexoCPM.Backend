using NexoCPM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Academic
{
    public class Specialization : AuditableEntity
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<EducationContext>? EducationContexts { get; set; } = new HashSet<EducationContext>();

        public Specialization() { }
    }
}
