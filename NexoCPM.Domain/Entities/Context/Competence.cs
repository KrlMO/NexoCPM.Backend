using NexoCPM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Academic
{
    public class Competence : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int EffectYear { get; set; }
        public bool IsActive { get; set; }

        public ICollection<CompetenceSyllabusTopic> CompetenceSyllabusTopics { get; set; } = new HashSet<CompetenceSyllabusTopic>();

        public Competence() { }
    }
}
