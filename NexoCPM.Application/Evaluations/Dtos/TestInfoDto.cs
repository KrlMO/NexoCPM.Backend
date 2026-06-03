namespace NexoCPM.Application.Evaluations.Dtos
{
    public class TestInfoDto
    {
        public int AssessmentId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Scope { get; set; } = string.Empty;
        public int TargetId { get; set; }
        public int NumberQuestions { get; set; }
        public int? TimeLimitSeconds { get; set; }
        public int MaxAttempts { get; set; }
        public int AttemptsUsed { get; set; }
        public int AttemptsRemaining { get; set; }
    }
}
