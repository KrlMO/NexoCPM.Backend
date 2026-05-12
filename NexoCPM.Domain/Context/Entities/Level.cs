using NexoCPM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Context.Entities
{
    public class Level : AuditableEntity
    {
        public int Id { get; private set; }
        public string Code { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public string Slug { get; private set; } = string.Empty;
        public int ModalityId { get; private set; }
        public bool IsActive { get; private set; } = true;
        public bool IsDeleted { get; private set; } = false;

        public Modality Modality { get; private set; } = null!;

        public ICollection<EducationContext> EducationContexts { get; private set; } = new List<EducationContext>();
        public Level() { }
    }
}
