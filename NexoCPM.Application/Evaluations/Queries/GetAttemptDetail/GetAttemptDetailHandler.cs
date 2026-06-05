using MediatR;
using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Evaluations.Dtos;
using NexoCPM.Application.Interfaces;
using NexoCPM.Domain.Common.Exceptions;

namespace NexoCPM.Application.Evaluations.Queries.GetAttemptDetail
{
    public class GetAttemptDetailHandler : IRequestHandler<GetAttemptDetailQuery, GetAttemptDetailResponse>
    {
        private readonly IApplicationDbContext _context;

        public GetAttemptDetailHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetAttemptDetailResponse> Handle(GetAttemptDetailQuery request, CancellationToken cancellationToken)
        {
            var ulc = await _context.UserLearningContexts
                .AsNoTracking()
                .FirstOrDefaultAsync(ulc =>
                    ulc.Id == request.UserLearningContextId
                    && ulc.UserId == request.UserId
                    && ulc.IsActive && !ulc.IsDeleted, cancellationToken);

            if (ulc is null)
                throw new NotFoundException("Contexto de aprendizaje no encontrado");

            var attempt = await _context.AssessmentAttempts
                .AsNoTracking()
                .Include(aa => aa.Assessment)
                .Include(aa => aa.AssessmentAttemptQuestions)
                    .ThenInclude(aaq => aaq.Question)
                .FirstOrDefaultAsync(aa =>
                    aa.Id == request.AttemptId
                    && aa.UserLearningContextId == request.UserLearningContextId
                    && aa.Status == Domain.Evaluations.Enums.AssessmentAttemptStatus.COMPLETED, cancellationToken);

            if (attempt is null)
                throw new NotFoundException("Intento no encontrado");

            var questionIds = attempt.AssessmentAttemptQuestions
                .Select(aaq => aaq.QuestionId)
                .ToList();

            var options = await _context.Options
                .AsNoTracking()
                .Where(o => questionIds.Contains(o.QuestionId))
                .ToListAsync(cancellationToken);

            var optionIds = options.Select(o => o.Id).ToList();

            var questionContexts = await _context.QuestionContexts
                .AsNoTracking()
                .Include(qc => qc.QuestionContentBlock)
                .Where(qc => questionIds.Contains(qc.QuestionId))
                .OrderBy(qc => qc.OrderIndex)
                .ToListAsync(cancellationToken);

            var optionBlocks = await _context.OptionBlocks
                .AsNoTracking()
                .Where(ob => optionIds.Contains(ob.OptionId))
                .OrderBy(ob => ob.OrderIndex)
                .ToListAsync(cancellationToken);

            var incorrectQuestionIds = attempt.AssessmentAttemptQuestions
                .Where(aaq =>
                {
                    if (!aaq.SelectedOptionId.HasValue)
                        return true;

                    var selectedOption = options.FirstOrDefault(o => o.Id == aaq.SelectedOptionId.Value);
                    return selectedOption is null || !selectedOption.IsCorrect;
                })
                .Select(aaq => aaq.QuestionId)
                .ToList();

            var recommendations = new List<string>();
            if (incorrectQuestionIds.Count > 0)
            {
                var incorrectSubTopicIds = await _context.Questions
                    .Where(q => incorrectQuestionIds.Contains(q.Id))
                    .Select(q => q.SubTopicId)
                    .Distinct()
                    .ToListAsync(cancellationToken);

                var subTopics = await _context.SubTopics
                    .Where(st => incorrectSubTopicIds.Contains(st.Id))
                    .Select(st => st.Description)
                    .ToListAsync(cancellationToken);

                recommendations = subTopics
                    .Select(name => $"Estudiar: {name}")
                    .ToList();
            }

            var questions = attempt.AssessmentAttemptQuestions
                .OrderBy(aaq => aaq.OrderIndex)
                .Select(aaq =>
                {
                    var questionOptions = options
                        .Where(o => o.QuestionId == aaq.QuestionId)
                        .ToList();

                    var correctOptionId = questionOptions
                        .FirstOrDefault(o => o.IsCorrect)
                        ?.Id;

                    var isCorrect = aaq.SelectedOptionId.HasValue
                        && questionOptions.Any(o => o.Id == aaq.SelectedOptionId.Value && o.IsCorrect);

                    var contextBlocks = questionContexts
                        .Where(qc => qc.QuestionId == aaq.QuestionId)
                        .Select(qc => new QuestionContentBlockDto
                        {
                            Id = qc.QuestionContentBlock.Id,
                            Title = qc.QuestionContentBlock.Title,
                            Content = qc.QuestionContentBlock.Content,
                            Code = qc.QuestionContentBlock.Code,
                            Type = qc.QuestionContentBlock.Type.ToString(),
                            Role = qc.QuestionContentBlock.Role.ToString(),
                            SourceText = qc.QuestionContentBlock.SourceText,
                            SourceUrl = qc.QuestionContentBlock.SourceUrl,
                            OrderIndex = qc.OrderIndex
                        })
                        .ToList();

                    return new AttemptQuestionDetailDto
                    {
                        QuestionId = aaq.QuestionId,
                        Statement = aaq.Question.Statement,
                        OrderIndex = aaq.OrderIndex,
                        SelectedOptionId = aaq.SelectedOptionId,
                        CorrectOptionId = correctOptionId,
                        IsCorrect = isCorrect,
                        ContextBlocks = contextBlocks,
                        Options = questionOptions.Select(o => new AttemptOptionDetailDto
                        {
                            OptionId = o.Id,
                            Label = o.Label,
                            IsCorrect = o.IsCorrect,
                            IsSelected = o.Id == aaq.SelectedOptionId,
                            Blocks = optionBlocks
                                .Where(ob => ob.OptionId == o.Id)
                                .Select(ob => new OptionBlockDto
                                {
                                    Id = ob.Id,
                                    Content = ob.Content,
                                    Type = ob.Type.ToString(),
                                    OrderIndex = ob.OrderIndex
                                })
                                .ToList()
                        }).ToList()
                    };
                })
                .ToList();

            var passed = attempt.Score >= 60;

            return new GetAttemptDetailResponse
            {
                AttemptId = attempt.Id,
                AssessmentId = attempt.AssessmentId,
                TotalQuestions = attempt.TotalQuestions,
                CorrectAnswers = attempt.CorrectAnswers,
                Score = attempt.Score,
                StarsEarned = attempt.StarsEarned,
                FinishedAt = attempt.FinishedAt,
                Passed = passed,
                Recommendations = recommendations,
                Questions = questions
            };
        }
    }
}
