using NexoCPM.Domain.Common;
using NexoCPM.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Curriculum.Entities
{
    public class Syllabus : AuditableEntity
    {
        public int Id { get; private set; }
        public string Code { get; private set; } = string.Empty;
        public string Slug { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public bool IsActive { get; private set; } = true;
        public bool IsDeleted { get; private set; } = false;
        public int EffectYear { get; private set; }
        public int MinCompetenceLevel { get; private set; }
        public int MaxCompetencLevel { get; private set; }

        public ICollection<SyllabusContext> SyllabusContexts { get; private set; } = new HashSet<SyllabusContext>();
        public ICollection<UserLearningContext> UserLearningContexts { get; private set; } = new HashSet<UserLearningContext>();
        public ICollection<SyllabusUnit> SyllabusUnits { get; private set; } = new HashSet<SyllabusUnit>();

        public Syllabus() { }
    }
}
