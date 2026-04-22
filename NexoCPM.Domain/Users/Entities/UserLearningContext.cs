using NexoCPM.Domain.Common;
using NexoCPM.Domain.Curriculum.Entities;
using NexoCPM.Domain.Evaluations.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Users.Entities
{
    public class UserLearningContext : AuditableEntity
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public int SyllabusId { get; private set; }
        public bool IsActive { get; private set; } = true;
        public bool IsDeleted { get; private set; } = false;

        public ICollection<AssessmentAttempt> AssessmentAttempts { get; private set; } = new List<AssessmentAttempt>();

        public UserSyllabusProgress UserSyllabusProgress { get; private set; } = null!;
        public User User { get; private set; } = null!;
        public Syllabus Syllabus { get; private set; } = null!;

        public UserLearningContext() { }

    }
}
