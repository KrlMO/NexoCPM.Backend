using NexoCPM.Domain.Common;
using NexoCPM.Domain.Context.Entities;
using NexoCPM.Domain.Evaluations.Entities;
using NexoCPM.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Curriculum.Entities
{
    public class SyllabusUnit : AuditableEntity
    {
        public int Id { get; private set; }
        public string Code { get; private set; } = string.Empty;
        public int SyllabusId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public int OrderIndex { get; private set; }
        public bool IsActive { get; private set; } = true;
        public bool IsDeleted { get; private set; } = false;
        public ICollection<UserSyllabusUnitProgress> UserSyllabusUnitProgresses { get; private set; } = new HashSet<UserSyllabusUnitProgress>();
        public ICollection<CompetenceLevelUnit> CompetenceLevelUnits { get; private set; } = new HashSet<CompetenceLevelUnit>();
        public ICollection<Topic> Topics { get; private set; } = new HashSet<Topic>();

        public Syllabus Syllabus { get; private set; } = null!;

        public SyllabusUnit() { }

    }
}
