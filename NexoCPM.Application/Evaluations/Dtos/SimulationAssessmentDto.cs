namespace NexoCPM.Application.Evaluations.Dtos
{
    public class SimulationAssessmentDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string SyllabusName { get; set; } = string.Empty;
        public int TargetId { get; set; }
        public int NumberQuestions { get; set; }
        public int? TimeLimitSeconds { get; set; }
    }
}
