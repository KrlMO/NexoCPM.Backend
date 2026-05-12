using NexoCPM.Domain.Common;
using NexoCPM.Domain.Users.Enums;
using System;
using System.Collections.Generic;

namespace NexoCPM.Domain.Users.Entities
{
    public class UserSyllabusProgress : AuditableEntity
    {
        public int Id { get; set; }
        public int UserLearningContextId { get; private set; }
        public DateTime LastAccess { get; private set; } = DateTime.Now;
        public UserProgressStatus Status { get; private set; } 

        public UserLearningContext UserLearningContext { get; private set; } = null!;
        public ICollection<UserSyllabusUnitProgress> UserSyllabusUnitProgresses { get; private set; } = new HashSet<UserSyllabusUnitProgress>();

        public UserSyllabusProgress() { }

        public UserSyllabusProgress(UserProgressStatus status)
        {
            Status = status;
            LastAccess = DateTime.Now;
        }

        public void SetInProgress()
        {
            Status = UserProgressStatus.IN_PROGRESS;
            LastAccess = DateTime.Now;
        }
    }
}
