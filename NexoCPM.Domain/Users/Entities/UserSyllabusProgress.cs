using NexoCPM.Domain.Common;
using NexoCPM.Domain.Curriculum.Entities;
using NexoCPM.Domain.Users.Enums;
using System;

namespace NexoCPM.Domain.Users.Entities
{
    public class UserSyllabusProgress : AuditableEntity
    {
        public int Id { get; set; }
        public int UserLearningContextId { get; private set; }
        public int UserId { get; private set; }
        public int SyllabusId { get; private set; }
        public int CompletedUnits { get; private set; }
        public int TotalUnits { get; private set; }
        public double ContentProgressPercentage { get; private set; }
        public bool FinalExamCompleted { get; private set; }
        public decimal? FinalExamScore { get; private set; }
        public double OverallProgressPercentage { get; private set; }
        public DateTime? CompletedAt { get; private set; }
        public DateTime LastAccess { get; private set; } = DateTime.UtcNow;
        public DateTime LastActivityAt { get; private set; } = DateTime.UtcNow;
        public UserProgressStatus Status { get; private set; }

        public UserLearningContext UserLearningContext { get; private set; } = null!;
        public ICollection<UserSyllabusUnitProgress> UserSyllabusUnitProgresses { get; private set; } = new HashSet<UserSyllabusUnitProgress>();

        public UserSyllabusProgress() { }

        public UserSyllabusProgress(UserProgressStatus status)
        {
            Status = status;
            LastAccess = DateTime.UtcNow;
            LastActivityAt = DateTime.UtcNow;
        }

        public void UpdateContentProgress(int completedUnits, int totalUnits, double unitAveragePercentage)
        {
            CompletedUnits = completedUnits;
            TotalUnits = totalUnits;
            ContentProgressPercentage = Math.Round(unitAveragePercentage, 2);
            RecalculateOverall();
        }

        public void MarkFinalExamCompleted(decimal score)
        {
            FinalExamCompleted = true;
            FinalExamScore = score;
            RecalculateOverall();
        }

        public void SetInProgress()
        {
            Status = UserProgressStatus.IN_PROGRESS;
            LastAccess = DateTime.UtcNow;
            LastActivityAt = DateTime.UtcNow;
        }

        private void RecalculateOverall()
        {
            OverallProgressPercentage = (ContentProgressPercentage * 0.8) + (FinalExamCompleted ? 20 : 0);
            OverallProgressPercentage = Math.Round(OverallProgressPercentage, 2);
            LastActivityAt = DateTime.UtcNow;

            if (OverallProgressPercentage >= 100)
                CompletedAt ??= DateTime.UtcNow;
            else
                CompletedAt = null;
        }
    }
}
