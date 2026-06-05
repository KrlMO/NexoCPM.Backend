using NexoCPM.Application.Evaluations.Commands.SubmitAssessmentAnswers;

namespace NexoCPM.Api.Controllers.Evaluations.Requests
{
    public class SubmitAnswersRequest
    {
        public string SyllabusSlug { get; set; } = string.Empty;
        public string? UnitSlug { get; set; }
        public List<AnswerDto> Answers { get; set; } = new();
    }
}
