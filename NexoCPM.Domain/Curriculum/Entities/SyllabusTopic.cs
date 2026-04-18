using NexoCPM.Domain.Common;
using NexoCPM.Domain.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Curriculum.Entities
{
    public class SyllabusTopic : AuditableEntity
    {
        public long Id { get; set; }
        public long SyllabusUnitId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
        public int CompetendeId { get; set; }

        public ICollection<Topic> Topics { get; set; } = new List<Topic>();
        public ICollection<CompetenceSyllabusTopic> CompetenceSyllabusTopics { get; set; } = new HashSet<CompetenceSyllabusTopic>();

        public required SyllabusUnit SyllabusUnit { get; set; }
        public required Competence Competence { get; set; }

        public SyllabusTopic() { }
    }
}
