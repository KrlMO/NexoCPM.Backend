using NexoCPM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Context.Entities
{
    public class Level : AuditableEntity
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long ModalityId { get; set; }

        public required Modality Modality { get; set; }

        public ICollection<EducationContext> EducationContexts { get; set; } = new List<EducationContext>();

        public Level() { }
    }
}
