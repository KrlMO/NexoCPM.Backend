using NexoCPM.Domain.Evaluations.Enums;
using NexoCPM.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Evaluations.Entities
{
    public class AssessmentAttempt
    {
        public int Id { get; private set; }
        public int AssessmentId { get; private set; }
        public int UserLearningContextId { get; private set; }
        public DateTime StartedAt { get; private set; } = DateTime.Now;
        public DateTime FinishedAt { get; private set; }
        public int Score { get; private set; }
        public int TotalQuestions { get; private set; }
        public int CorrectAnswers { get; private set; }
        public int StarsEarned { get; private set; } = 0;
        public AssessmentGenerationMode? GenerationModeUsed { get; private set; }
        public AssessmentAttemptStatus Status { get; private set; } = AssessmentAttemptStatus.IN_PROGRESS;

        public ICollection<AssessmentAttemptQuestion> AssessmentAttemptQuestions { get; private set; } = new List<AssessmentAttemptQuestion>();

        public Assessment Assessment { get; private set; } = null!;
        public UserLearningContext UserLearningContext { get; private set; } = null!;

        public AssessmentAttempt() { }

        public AssessmentAttempt(int assessmentId, int userLearningContextId, int totalQuestions, AssessmentGenerationMode? generationMode)
        {
            AssessmentId = assessmentId;
            UserLearningContextId = userLearningContextId;
            TotalQuestions = totalQuestions;
            GenerationModeUsed = generationMode;
            Status = AssessmentAttemptStatus.IN_PROGRESS;
            StartedAt = DateTime.Now;
        }

        public void Complete(int correctAnswers, int starsEarned)
        {
            FinishedAt = DateTime.Now;
            CorrectAnswers = correctAnswers;
            Score = TotalQuestions > 0
                ? (int)Math.Round((double)correctAnswers / TotalQuestions * 100)
                : 0;
            StarsEarned = starsEarned;
            Status = AssessmentAttemptStatus.COMPLETED;
        }
    }
}
