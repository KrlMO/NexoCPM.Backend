using MediatR;

namespace NexoCPM.Application.Evaluations.Commands.SubmitAssessmentAnswers
{
    public record SubmitAssessmentAnswersCommand(
        int UserId,
        int UserLearningContextId,
        int AttemptId,
        string SyllabusSlug,
        string? UnitSlug,
        List<AnswerDto> Answers
    ) : IRequest<SubmitAssessmentAnswersResponse>;

    public record AnswerDto(int QuestionId, int? SelectedOptionId);
}
