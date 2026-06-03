namespace NexoCPM.Application.Evaluations.Dtos
{
    public class AttemptQuestionDto
    {
        public int QuestionId { get; set; }
        public string Statement { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
        public List<QuestionContentBlockDto> ContextBlocks { get; set; } = new();
        public List<AttemptOptionDto> Options { get; set; } = new();
    }

    public class QuestionContentBlockDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string? SourceText { get; set; }
        public string? SourceUrl { get; set; }
        public int OrderIndex { get; set; }
    }

    public class AttemptOptionDto
    {
        public int OptionId { get; set; }
        public string Label { get; set; } = string.Empty;
        public List<OptionBlockDto> Blocks { get; set; } = new();
    }

    public class OptionBlockDto
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
    }
}
