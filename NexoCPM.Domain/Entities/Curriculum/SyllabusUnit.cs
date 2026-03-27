using NexoCPM.Domain.Common;
using NexoCPM.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Curriculum
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
