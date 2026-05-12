using NexoCPM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Context.Entities
{
    public class Specialization : AuditableEntity
    {
        public int Id { get; private set; }
        public string Code { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public string Slug { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public bool IsActive { get; private set; } = true;
        public bool IsDeleted { get; private set; } = false;

        public ICollection<EducationContext>? EducationContexts { get; private set; } = new HashSet<EducationContext>();

        public Specialization() { }
    }
}
