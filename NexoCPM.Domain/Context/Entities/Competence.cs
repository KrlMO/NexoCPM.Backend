using NexoCPM.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Context.Entities
{
    public class Competence : AuditableEntity
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public int EffectYear { get; private set; }
        public bool IsActive { get; private set; }

        public ICollection<CompetenceSyllabusTopic> CompetenceSyllabusTopics { get; private set; } = new HashSet<CompetenceSyllabusTopic>();

        public Competence() { }
    }
}
