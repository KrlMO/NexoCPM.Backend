using NexoCPM.Application.Evaluations.Dtos;
using NexoCPM.Domain.Evaluations.Enums;

namespace NexoCPM.Application.Evaluations.Commands.StartAssessmentAttemptSimulation
{
    public class StartAssessmentAttemptSimulationResponse
    {
        public int AttemptId { get; set; }
        public int AssessmentId { get; set; }
        public DateTime StartedAt { get; set; }
        public int? TimeLimitSeconds { get; set; }
        public int TotalQuestions { get; set; }
        public AssessmentGenerationMode GenerationModeUsed { get; set; }
        public string Title { get; set; } = string.Empty;
        public List<AttemptQuestionDto> Questions { get; set; } = new();
    }
}
