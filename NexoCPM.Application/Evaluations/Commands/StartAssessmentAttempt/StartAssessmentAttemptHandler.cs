using MediatR;
using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Interfaces;
using NexoCPM.Domain.Common.Exceptions;
using NexoCPM.Domain.Evaluations.Entities;
using NexoCPM.Domain.Evaluations.Enums;

namespace NexoCPM.Application.Evaluations.Commands.StartAssessmentAttempt
{
    public class StartAssessmentAttemptHandler : IRequestHandler<StartAssessmentAttemptCommand, StartAssessmentAttemptResponse>
    {
        private readonly IApplicationDbContext _context;

        public StartAssessmentAttemptHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StartAssessmentAttemptResponse> Handle(StartAssessmentAttemptCommand request, CancellationToken cancellationToken)
        {
            var assessment = await _context.Assessments
                .FirstOrDefaultAsync(a => a.Id == request.AssessmentId && a.IsActive, cancellationToken);

            if (assessment is null)
                throw new NotFoundException("Evaluación no encontrada");

            var userLearningContext = await _context.UserLearningContexts
                .FirstOrDefaultAsync(ulc =>
                    ulc.Id == request.UserLearningContextId
                    && ulc.UserId == request.UserId
                    && ulc.IsActive && !ulc.IsDeleted, cancellationToken);

            if (userLearningContext is null)
                throw new NotFoundException("Contexto de aprendizaje no encontrado");

            var attemptsUsed = await _context.AssessmentAttempts
                .CountAsync(aa =>
                    aa.AssessmentId == assessment.Id
                    && aa.UserLearningContextId == request.UserLearningContextId, cancellationToken);

            var maxAttempts = assessment.MaxAttempts ?? 1;
            if (attemptsUsed >= maxAttempts)
                throw new ConflictException("Has alcanzado el número máximo de intentos permitidos");

            if (assessment.TargetId is null)
                throw new NotFoundException("La evaluación no tiene un objetivo asociado");

            var subTopicIds = await GetSubTopicIds(assessment.Scope, assessment.TargetId.Value, cancellationToken);

            if (subTopicIds.Count == 0)
                throw new NotFoundException("No se encontraron preguntas disponibles para esta evaluación");

            var questionsQuery = _context.Questions
                .Where(q => subTopicIds.Contains(q.SubTopicId) && q.IsActive && !q.IsDeleted);

            var totalAvailable = await questionsQuery.CountAsync(cancellationToken);
            if (totalAvailable == 0)
                throw new NotFoundException("No se encontraron preguntas disponibles para esta evaluación");

            var questionCount = Math.Min(assessment.NumberQuestions, totalAvailable);

            List<Question> selectedQuestions;
            if (assessment.ShuffleQuestions)
            {
                var allQuestions = await questionsQuery.ToListAsync(cancellationToken);
                var rng = Random.Shared;
                selectedQuestions = allQuestions.OrderBy(_ => rng.Next()).Take(questionCount).ToList();
            }
            else
            {
                selectedQuestions = await questionsQuery
                    .OrderBy(q => q.Id)
                    .Take(questionCount)
                    .ToListAsync(cancellationToken);
            }

            var questionIds = selectedQuestions.Select(q => q.Id).ToList();
            var options = await _context.Options
                .Where(o => questionIds.Contains(o.QuestionId))
                .ToListAsync(cancellationToken);

            var questionContexts = await _context.QuestionContexts
                .Where(qc => questionIds.Contains(qc.QuestionId))
                .OrderBy(qc => qc.OrderIndex)
                .ToListAsync(cancellationToken);

            var contentBlockIds = questionContexts.Select(qc => qc.QuestionContentBlockId).Distinct().ToList();
            var contentBlocks = contentBlockIds.Count > 0
                ? await _context.QuestionContentBlocks
                    .Where(cb => contentBlockIds.Contains(cb.Id))
                    .ToListAsync(cancellationToken)
                : [];

            var optionIds = options.Select(o => o.Id).ToList();
            var optionBlocks = optionIds.Count > 0
                ? await _context.OptionBlocks
                    .Where(ob => optionIds.Contains(ob.OptionId))
                    .OrderBy(ob => ob.OrderIndex)
                    .ToListAsync(cancellationToken)
                : [];

            var attempt = new AssessmentAttempt(assessment.Id, request.UserLearningContextId, selectedQuestions.Count, assessment.GenerationMode);
            _context.AssessmentAttempts.Add(attempt);

            for (int i = 0; i < selectedQuestions.Count; i++)
            {
                var question = selectedQuestions[i];
                var questionOptions = options.Where(o => o.QuestionId == question.Id).ToList();

                string optionOrderStr;
                if (assessment.ShuffleOptions)
                {
                    optionOrderStr = string.Join(",", questionOptions.OrderBy(_ => Random.Shared.Next()).Select(o => o.Id));
                }
                else
                {
                    optionOrderStr = string.Join(",", questionOptions.OrderBy(o => o.Id).Select(o => o.Id));
                }

                attempt.AssessmentAttemptQuestions.Add(new AssessmentAttemptQuestion(question.Id, i + 1, optionOrderStr));
            }

            await _context.SaveChangesAsync(cancellationToken);

            var questionsDto = selectedQuestions.Select(q =>
            {
                var questionOptions = options.Where(o => o.QuestionId == q.Id).ToList();
                var aaq = attempt.AssessmentAttemptQuestions.First(a => a.QuestionId == q.Id);

                var qContexts = questionContexts.Where(qc => qc.QuestionId == q.Id).ToList();
                var contextBlocksDto = qContexts
                    .Select(qc => contentBlocks.FirstOrDefault(b => b.Id == qc.QuestionContentBlockId))
                    .Where(cb => cb is not null)
                    .Select(cb => new Dtos.QuestionContentBlockDto
                    {
                        Id = cb!.Id,
                        Title = cb.Title,
                        Content = cb.Content,
                        Code = cb.Code,
                        Type = cb.Type.ToString(),
                        Role = cb.Role.ToString(),
                        SourceText = cb.SourceText,
                        SourceUrl = cb.SourceUrl,
                        OrderIndex = qContexts.First(qc => qc.QuestionContentBlockId == cb.Id).OrderIndex
                    })
                    .ToList();

                var optionIdsInOrder = aaq.OptionDisplayOrder?
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList() ?? [];

                var orderedOptions = optionIdsInOrder
                    .Select(id => questionOptions.FirstOrDefault(o => o.Id == id))
                    .Where(o => o is not null)
                    .Select(o =>
                    {
                        var optBlocks = optionBlocks.Where(ob => ob.OptionId == o!.Id)
                            .OrderBy(ob => ob.OrderIndex)
                            .Select(ob => new Dtos.OptionBlockDto
                            {
                                Id = ob.Id,
                                Content = ob.Content,
                                Type = ob.Type.ToString(),
                                OrderIndex = ob.OrderIndex
                            })
                            .ToList();

                        return new Dtos.AttemptOptionDto
                        {
                            OptionId = o!.Id,
                            Label = o.Label,
                            Blocks = optBlocks
                        };
                    })
                    .ToList();

                return new Dtos.AttemptQuestionDto
                {
                    QuestionId = q.Id,
                    Statement = q.Statement,
                    OrderIndex = aaq.OrderIndex,
                    ContextBlocks = contextBlocksDto,
                    Options = orderedOptions
                };
            }).ToList();

            return new StartAssessmentAttemptResponse
            {
                AttemptId = attempt.Id,
                AssessmentId = assessment.Id,
                StartedAt = attempt.StartedAt,
                TimeLimitSeconds = assessment.TimeLimitSeconds,
                TotalQuestions = selectedQuestions.Count,
                Questions = questionsDto
            };
        }

        private async Task<List<int>> GetSubTopicIds(AssessmentScope scope, int targetId, CancellationToken cancellationToken)
        {
            if (scope == AssessmentScope.UNIT)
            {
                return await _context.SubTopics
                    .Where(st => st.Topic.SyllabusUnitId == targetId && st.IsActive && !st.IsDeleted)
                    .Select(st => st.Id)
                    .ToListAsync(cancellationToken);
            }
            else if (scope == AssessmentScope.SYLLABUS)
            {
                return await _context.SubTopics
                    .Where(st => st.Topic.SyllabusUnit.SyllabusId == targetId && st.IsActive && !st.IsDeleted)
                    .Select(st => st.Id)
                    .ToListAsync(cancellationToken);
            }
            else if (scope == AssessmentScope.SIMULATION)
            {
                return await _context.SubTopics
                    .Where(st => st.Topic.SyllabusUnit.SyllabusId == targetId && st.IsActive && !st.IsDeleted)
                    .Select(st => st.Id)
                    .ToListAsync(cancellationToken);
            }

            return [];
        }
    }
}
