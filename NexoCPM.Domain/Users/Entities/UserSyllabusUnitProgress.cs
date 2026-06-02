using NexoCPM.Domain.Common;
using NexoCPM.Domain.Curriculum.Entities;
using NexoCPM.Domain.Users.Enums;
using System;

namespace NexoCPM.Domain.Users.Entities
{
    public class UserSyllabusUnitProgress : AuditableEntity
    {
        public int Id { get; private set; }
        public int UserSyllabusProgressId { get; private set; }
        public int SyllabusUnitId { get; private set; }
        public UserModuleProgressStatus Status { get; private set; }
        public int TotalQuestions { get; private set; }
        public int TotalCorrect { get; private set; }
        public int Attempts { get; private set; } = 0;
        public double Score => TotalQuestions == 0 ? 0 : (double)TotalCorrect / TotalQuestions;
        public DateTime LastAttemptAt { get; private set; } = DateTime.Now;
        public int UserId { get; private set; }
        public int CompletedSubTopics { get; private set; }
        public int TotalSubTopics { get; private set; }
        public double ContentProgressPercentage { get; private set; }
        public bool UnitExamCompleted { get; private set; }
        public decimal? UnitExamScore { get; private set; }
        public double OverallProgressPercentage { get; private set; }
        public DateTime? CompletedAt { get; private set; }

        public SyllabusUnit SyllabusUnit { get; private set; } = null!;
        public UserSyllabusProgress UserSyllabusProgress { get; private set; } = null!;
        public ICollection<UserSubTopicView> UserSubTopicViews { get; private set; } = new HashSet<UserSubTopicView>();

        public UserSyllabusUnitProgress() { }

        public UserSyllabusUnitProgress(int userSyllabusProgressId, int syllabusUnitId, int userId)
        {
            UserSyllabusProgressId = userSyllabusProgressId;
            SyllabusUnitId = syllabusUnitId;
            UserId = userId;
        }

        public void UpdateContentProgress(int completedSubTopics, int totalSubTopics)
        {
            CompletedSubTopics = completedSubTopics;
            TotalSubTopics = totalSubTopics;
            ContentProgressPercentage = totalSubTopics > 0
                ? Math.Round((double)completedSubTopics / totalSubTopics * 100, 2)
                : 0;
            RecalculateOverall();
        }

        public void MarkUnitExamCompleted(decimal score)
        {
            UnitExamCompleted = true;
            UnitExamScore = score;
            RecalculateOverall();
        }

        private void RecalculateOverall()
        {
            OverallProgressPercentage = (ContentProgressPercentage * 0.7) + (UnitExamCompleted ? 30 : 0);
            OverallProgressPercentage = Math.Round(OverallProgressPercentage, 2);

            if (OverallProgressPercentage >= 100)
                CompletedAt ??= DateTime.UtcNow;
            else
                CompletedAt = null;
        }
    }
}
