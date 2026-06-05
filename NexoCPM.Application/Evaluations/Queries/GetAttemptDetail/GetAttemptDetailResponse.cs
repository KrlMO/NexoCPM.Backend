using NexoCPM.Application.Evaluations.Dtos;

namespace NexoCPM.Application.Evaluations.Queries.GetAttemptDetail
{
    public class GetAttemptDetailResponse
    {
        public int AttemptId { get; set; }
        public int AssessmentId { get; set; }
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public int Score { get; set; }
        public int StarsEarned { get; set; }
        public DateTime? FinishedAt { get; set; }
        public bool Passed { get; set; }
        public List<string> Recommendations { get; set; } = new();
        public List<AttemptQuestionDetailDto> Questions { get; set; } = new();
    }

    public class AttemptQuestionDetailDto
    {
        public int QuestionId { get; set; }
        public string Statement { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
        public int? SelectedOptionId { get; set; }
        public int? CorrectOptionId { get; set; }
        public bool IsCorrect { get; set; }
        public List<QuestionContentBlockDto> ContextBlocks { get; set; } = new();
        public List<AttemptOptionDetailDto> Options { get; set; } = new();
    }

    public class AttemptOptionDetailDto
    {
        public int OptionId { get; set; }
        public string Label { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
        public bool IsSelected { get; set; }
        public List<OptionBlockDto> Blocks { get; set; } = new();
    }
}
