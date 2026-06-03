using NexoCPM.Application.Evaluations.Dtos;

namespace NexoCPM.Application.Evaluations.Commands.StartAssessmentAttempt
{
    public class StartAssessmentAttemptResponse
    {
        public int AttemptId { get; set; }
        public int AssessmentId { get; set; }
        public DateTime StartedAt { get; set; }
        public int? TimeLimitSeconds { get; set; }
        public int TotalQuestions { get; set; }
        public List<AttemptQuestionDto> Questions { get; set; } = new();
    }
}
