using NexoCPM.Domain.Common;
using NexoCPM.Domain.Curriculum.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Context.Entities
{
    public class Competence : AuditableEntity
    {
        public int Id { get; private set; }
        public string Code { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public int EffectYear { get; private set; }
        public bool IsActive { get; private set; } = true;

        public ICollection<CompetenceLevel> CompetenceLevels { get; private set; } = new HashSet<CompetenceLevel>();
        public ICollection<Ability> Abilities { get; private set; } = new HashSet<Ability>();
        public ICollection<SubTopic> SubTopics { get; private set; } = new HashSet<SubTopic>();
        public Competence() { }

        public Competence(string code, string name, string description, int effectYear)
        {
            Code = code;
            Name = name;
            Description = description;
            EffectYear = effectYear;
            IsActive = true;
        }

        public void Update(string name, string description, int effectYear)
        {
            Name = name;
            Description = description;
            EffectYear = effectYear;
        }
    }
}
