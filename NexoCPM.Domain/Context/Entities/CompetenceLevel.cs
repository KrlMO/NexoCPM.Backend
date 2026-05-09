using NexoCPM.Domain.Common;
using NexoCPM.Domain.Curriculum.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Context.Entities
{
    public class CompetenceLevel : AuditableEntity
    {
        public int Id { get; private set; }
        public int CompetenceId { get; private set; }
        public string Code { get; private set; } = string.Empty;
        public int LevelNumber { get; private set; }
        public string Description { get; private set; } = string.Empty;

        public ICollection<SubTopic> SubTopics { get; private set; } = new HashSet<SubTopic>();

        public Competence Competence { get; private set; } = null!;

        public CompetenceLevel() { }


    }
}
