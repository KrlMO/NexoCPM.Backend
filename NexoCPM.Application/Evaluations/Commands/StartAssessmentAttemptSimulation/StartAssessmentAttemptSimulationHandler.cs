using MediatR;
using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Evaluations.Dtos;
using NexoCPM.Application.Interfaces;
using NexoCPM.Domain.Common.Exceptions;
using NexoCPM.Domain.Evaluations.Entities;
using NexoCPM.Domain.Evaluations.Enums;
using NexoCPM.Domain.Users.Entities;

namespace NexoCPM.Application.Evaluations.Commands.StartAssessmentAttemptSimulation
{
    public class StartAssessmentAttemptSimulationHandler
        : IRequestHandler<StartAssessmentAttemptSimulationCommand, StartAssessmentAttemptSimulationResponse>
    {
        private readonly IApplicationDbContext _context;

        public StartAssessmentAttemptSimulationHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StartAssessmentAttemptSimulationResponse> Handle(
            StartAssessmentAttemptSimulationCommand request,
            CancellationToken cancellationToken)
        {
            var assessment = await _context.Assessments
                .FirstOrDefaultAsync(a => a.Id == request.AssessmentId && a.IsActive, cancellationToken);

            if (assessment is null)
                throw new NotFoundException("Simulacro no encontrado");

            if (assessment.Scope != AssessmentScope.SIMULATION)
                throw new ConflictException("La evaluación no es un simulacro");

            if (assessment.TargetId is null)
                throw new NotFoundException("El simulacro no tiene un objetivo asociado");

            var syllabusId = assessment.TargetId.Value;

            var ulc = await ResolveUserLearningContext(request.UserId, syllabusId, cancellationToken);

            var hasHistoricalData = await HasWrongAnswersInSyllabus(request.UserId, syllabusId, cancellationToken);

            if (!hasHistoricalData && request.GenerationMode != AssessmentGenerationMode.RANDOM)
                throw new ConflictException(
                    $"No hay suficiente historial de evaluaciones en este temario para usar el modo {request.GenerationMode}. Use el modo RANDOM.");

            var syllabus = await _context.Syllabi
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.Id == syllabusId, cancellationToken);

            var subTopicIds = await GetSubTopicIds(assessment.Scope, syllabusId, cancellationToken);

            if (subTopicIds.Count == 0)
                throw new NotFoundException("No se encontraron preguntas disponibles para este simulacro");

            var questionsQuery = _context.Questions
                .Where(q => subTopicIds.Contains(q.SubTopicId) && q.IsActive && !q.IsDeleted);

            var totalAvailable = await questionsQuery.CountAsync(cancellationToken);
            if (totalAvailable == 0)
                throw new NotFoundException("No se encontraron preguntas disponibles para este simulacro");

            var allQuestions = await questionsQuery.ToListAsync(cancellationToken);
            var questionCount = Math.Min(assessment.NumberQuestions, totalAvailable);

            var selectedQuestions = await SelectQuestions(
                allQuestions,
                questionCount,
                request.GenerationMode,
                request.UserId,
                syllabusId,
                hasHistoricalData,
                cancellationToken);

            if (assessment.ShuffleQuestions)
            {
                var rng = Random.Shared;
                selectedQuestions = selectedQuestions.OrderBy(_ => rng.Next()).ToList();
            }
            else
            {
                selectedQuestions = selectedQuestions.OrderBy(q => q.Id).ToList();
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

            var attempt = new AssessmentAttempt(
                assessment.Id,
                ulc.Id,
                selectedQuestions.Count,
                request.GenerationMode);

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

                attempt.AssessmentAttemptQuestions.Add(
                    new AssessmentAttemptQuestion(question.Id, i + 1, optionOrderStr));
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
                    .Select(cb => new QuestionContentBlockDto
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
                            .Select(ob => new OptionBlockDto
                            {
                                Id = ob.Id,
                                Content = ob.Content,
                                Type = ob.Type.ToString(),
                                OrderIndex = ob.OrderIndex
                            })
                            .ToList();

                        return new AttemptOptionDto
                        {
                            OptionId = o!.Id,
                            Label = o.Label,
                            Blocks = optBlocks
                        };
                    })
                    .ToList();

                return new AttemptQuestionDto
                {
                    QuestionId = q.Id,
                    Statement = q.Statement,
                    OrderIndex = aaq.OrderIndex,
                    ContextBlocks = contextBlocksDto,
                    Options = orderedOptions
                };
            }).ToList();

            return new StartAssessmentAttemptSimulationResponse
            {
                AttemptId = attempt.Id,
                AssessmentId = assessment.Id,
                StartedAt = attempt.StartedAt,
                TimeLimitSeconds = assessment.TimeLimitSeconds,
                TotalQuestions = selectedQuestions.Count,
                GenerationModeUsed = request.GenerationMode,
                Title = syllabus is not null ? $"Simulacro de {syllabus.Name}" : "Simulacro",
                Questions = questionsDto
            };
        }

        private async Task<UserLearningContext> ResolveUserLearningContext(int userId, int syllabusId, CancellationToken cancellationToken)
        {
            var ulc = await _context.UserLearningContexts
                .FirstOrDefaultAsync(ulc =>
                    ulc.UserId == userId
                    && ulc.SyllabusId == syllabusId
                    && ulc.IsActive && !ulc.IsDeleted, cancellationToken);

            if (ulc is not null)
                return ulc;

            ulc = new UserLearningContext(userId, syllabusId);
            _context.UserLearningContexts.Add(ulc);
            await _context.SaveChangesAsync(cancellationToken);

            return ulc;
        }

        private async Task<List<Question>> SelectQuestions(
            List<Question> allQuestions,
            int questionCount,
            AssessmentGenerationMode mode,
            int userId,
            int syllabusId,
            bool hasHistoricalData,
            CancellationToken cancellationToken)
        {
            if (mode == AssessmentGenerationMode.RANDOM || !hasHistoricalData)
            {
                return allQuestions.OrderBy(_ => Random.Shared.Next()).Take(questionCount).ToList();
            }

            var ulcIds = await _context.UserLearningContexts
                .Where(ulc => ulc.UserId == userId && ulc.SyllabusId == syllabusId && ulc.IsActive && !ulc.IsDeleted)
                .Select(ulc => ulc.Id)
                .ToListAsync(cancellationToken);

            var wrongSubTopicIds = await _context.AssessmentAttempts
                .Where(aa => ulcIds.Contains(aa.UserLearningContextId))
                .SelectMany(aa => aa.AssessmentAttemptQuestions)
                .Where(aaq => aaq.SelectedOptionId.HasValue && !aaq.SelectedOption!.IsCorrect)
                .Select(aaq => aaq.Question.SubTopicId)
                .Distinct()
                .ToListAsync(cancellationToken);

            var weakQuestions = allQuestions.Where(q => wrongSubTopicIds.Contains(q.SubTopicId)).ToList();
            var otherQuestions = allQuestions.Where(q => !wrongSubTopicIds.Contains(q.SubTopicId)).ToList();

            if (mode == AssessmentGenerationMode.BALANCED)
            {
                var fromWeakCount = Math.Min(questionCount / 2, weakQuestions.Count);
                var fromWeak = weakQuestions.OrderBy(_ => Random.Shared.Next()).Take(fromWeakCount).ToList();
                var remaining = questionCount - fromWeak.Count;
                var fromOthers = otherQuestions
                    .Concat(weakQuestions.Except(fromWeak))
                    .OrderBy(_ => Random.Shared.Next())
                    .Take(remaining)
                    .ToList();

                return fromWeak.Concat(fromOthers).ToList();
            }
            else
            {
                var weakCount = (int)Math.Ceiling(questionCount * 0.8);
                var fromWeakCount = Math.Min(weakCount, weakQuestions.Count);
                var fromWeak = weakQuestions.OrderBy(_ => Random.Shared.Next()).Take(fromWeakCount).ToList();
                var remaining = questionCount - fromWeak.Count;
                var fromOthers = otherQuestions
                    .Concat(weakQuestions.Except(fromWeak))
                    .OrderBy(_ => Random.Shared.Next())
                    .Take(remaining)
                    .ToList();

                return fromWeak.Concat(fromOthers).ToList();
            }
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

        private async Task<bool> HasWrongAnswersInSyllabus(int userId, int syllabusId, CancellationToken cancellationToken)
        {
            var ulcIds = await _context.UserLearningContexts
                .Where(ulc => ulc.UserId == userId && ulc.SyllabusId == syllabusId && ulc.IsActive && !ulc.IsDeleted)
                .Select(ulc => ulc.Id)
                .ToListAsync(cancellationToken);

            if (ulcIds.Count == 0)
                return false;

            return await _context.AssessmentAttempts
                .Where(aa => ulcIds.Contains(aa.UserLearningContextId))
                .SelectMany(aa => aa.AssessmentAttemptQuestions)
                .AnyAsync(aaq => aaq.SelectedOptionId.HasValue && !aaq.SelectedOption!.IsCorrect, cancellationToken);
        }
    }
}
