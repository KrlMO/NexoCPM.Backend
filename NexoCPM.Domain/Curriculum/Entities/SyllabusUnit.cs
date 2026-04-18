using NexoCPM.Domain.Common;
using NexoCPM.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Curriculum.Entities
{
    public class SyllabusUnit : AuditableEntity
    {
        public long Id { get; set; }
        public int SyllabusId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int OrderIndex { get; set; }

        public ICollection<UserSyllabusUnitProgress> UserSyllabusUnitProgresses { get; set; } = new HashSet<UserSyllabusUnitProgress>();

        public required Syllabus Syllabus { get; set; }

        public SyllabusUnit() { }

    }
}
