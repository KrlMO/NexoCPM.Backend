using System;

namespace NexoCPM.Application.Users.Dtos
{
    public class AssessmentChartDto
    {
        public int AttemptId { get; set; }
        public int AssessmentId { get; set; }
        public string AssessmentTitle { get; set; } = string.Empty;
        public int Score { get; set; }
        public int TotalQuestions { get; set; }
        public DateTime FinishedAt { get; set; }
    }
}
