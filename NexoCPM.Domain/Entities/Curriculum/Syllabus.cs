using NexoCPM.Domain.Common;
using NexoCPM.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Curriculum
{
    public class Syllabus : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public ICollection<UserSyllabusProgress> UserSyllabusProgresses { get; set; } = new List<UserSyllabusProgress>(); 
        public ICollection<SyllabusContext> SyllabusContexts { get; set; } = new HashSet<SyllabusContext>();

        public Syllabus() { }
    }
}
