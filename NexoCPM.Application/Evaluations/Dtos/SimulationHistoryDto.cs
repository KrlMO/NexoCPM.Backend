using System;

namespace NexoCPM.Application.Evaluations.Dtos
{
    public class SimulationHistoryDto
    {
        public int AttemptId { get; set; }
        public int AssessmentId { get; set; }
        public string AssessmentCode { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string SyllabusName { get; set; } = string.Empty;
        public string SyllabusSlug { get; set; } = string.Empty;
        public int Score { get; set; }
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public int StarsEarned { get; set; }
        public int DurationMinutes { get; set; }
        public DateTime FinishedAt { get; set; }
    }
}
