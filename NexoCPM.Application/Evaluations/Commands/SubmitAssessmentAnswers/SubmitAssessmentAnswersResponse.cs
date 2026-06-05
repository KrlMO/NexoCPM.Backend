namespace NexoCPM.Application.Evaluations.Commands.SubmitAssessmentAnswers
{
    public class SubmitAssessmentAnswersResponse
    {
        public int AttemptId { get; set; }
        public int AssessmentId { get; set; }
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public int Score { get; set; }
        public int StarsEarned { get; set; }
        public DateTime FinishedAt { get; set; }
        public bool Passed { get; set; }
        public List<string> Recommendations { get; set; } = new();
    }
}
