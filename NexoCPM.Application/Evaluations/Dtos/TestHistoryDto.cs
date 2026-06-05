namespace NexoCPM.Application.Evaluations.Dtos
{
    public class TestHistoryDto
    {
        public int AttemptId { get; set; }
        public DateTime? FinishedAt { get; set; }
        public bool Passed { get; set; }
        public int Score { get; set; }
        public int StarsEarned { get; set; }
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
    }
}
