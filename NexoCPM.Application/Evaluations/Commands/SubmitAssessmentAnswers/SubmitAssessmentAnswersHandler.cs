using MediatR;
using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Evaluations.Common;
using NexoCPM.Application.Interfaces;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Common.Exceptions;
using NexoCPM.Domain.Evaluations.Enums;
using NexoCPM.Domain.Users.Enums;

namespace NexoCPM.Application.Evaluations.Commands.SubmitAssessmentAnswers
{
    public class SubmitAssessmentAnswersHandler : IRequestHandler<SubmitAssessmentAnswersCommand, SubmitAssessmentAnswersResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IUserSyllabusProgressRepository _syllabusProgressRepository;
        private readonly IUserSyllabusUnitProgressRepository _unitProgressRepository;
        private readonly IUserLeaderboardRepository _leaderboardRepository;
        private readonly IMediator _mediator;

        public SubmitAssessmentAnswersHandler(
            IApplicationDbContext context,
            IUserSyllabusProgressRepository syllabusProgressRepository,
            IUserSyllabusUnitProgressRepository unitProgressRepository,
            IUserLeaderboardRepository leaderboardRepository,
            IMediator mediator)
        {
            _context = context;
            _syllabusProgressRepository = syllabusProgressRepository;
            _unitProgressRepository = unitProgressRepository;
            _leaderboardRepository = leaderboardRepository;
            _mediator = mediator;
        }

        public async Task<SubmitAssessmentAnswersResponse> Handle(SubmitAssessmentAnswersCommand request, CancellationToken cancellationToken)
        {
            var attempt = await _context.AssessmentAttempts
                .Include(aa => aa.Assessment)
                .Include(aa => aa.AssessmentAttemptQuestions)
                .FirstOrDefaultAsync(aa =>
                    aa.Id == request.AttemptId
                    && aa.UserLearningContextId == request.UserLearningContextId
                    && aa.Status == AssessmentAttemptStatus.IN_PROGRESS, cancellationToken);

            if (attempt is null)
                throw new NotFoundException("Intento no encontrado o ya fue completado");

            var assessment = attempt.Assessment;

            if (request.Answers.Count != assessment.NumberQuestions)
                throw new ConflictException($"La cantidad de respuestas no coincide con el número de preguntas de la evaluación ({assessment.NumberQuestions})");

            var attemptQuestionIds = attempt.AssessmentAttemptQuestions.Select(aaq => aaq.QuestionId).ToHashSet();
            var invalidQuestions = request.Answers.Where(a => !attemptQuestionIds.Contains(a.QuestionId)).ToList();
            if (invalidQuestions.Count > 0)
                throw new ConflictException("Una o más preguntas no pertenecen a este intento");

            var answeredOptions = request.Answers
                .Where(a => a.SelectedOptionId.HasValue)
                .Select(a => a.SelectedOptionId!.Value)
                .ToList();

            var options = answeredOptions.Count > 0
                ? await _context.Options
                    .Where(o => answeredOptions.Contains(o.Id))
                    .ToListAsync(cancellationToken)
                : new();

            var correctCount = 0;
            var incorrectQuestionIds = new List<int>();

            foreach (var answer in request.Answers)
            {
                var aaq = attempt.AssessmentAttemptQuestions
                    .First(a => a.QuestionId == answer.QuestionId);

                aaq.SelectOption(answer.SelectedOptionId);

                if (answer.SelectedOptionId.HasValue)
                {
                    var option = options.FirstOrDefault(o => o.Id == answer.SelectedOptionId.Value);
                    if (option is not null && option.IsCorrect)
                    {
                        correctCount++;
                        continue;
                    }
                }

                incorrectQuestionIds.Add(answer.QuestionId);
            }

            var starsEarned = assessment.Scope == AssessmentScope.SYLLABUS
                ? StarCalculator.CalculateStars(correctCount, attempt.TotalQuestions)
                : 0;

            attempt.Complete(correctCount, starsEarned);

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

            var passed = attempt.Score >= 60;

            if (assessment.Scope == AssessmentScope.UNIT && !string.IsNullOrWhiteSpace(request.UnitSlug))
            {
                var ulc = await _context.UserLearningContexts
                    .FirstOrDefaultAsync(ulc =>
                        ulc.Id == request.UserLearningContextId
                        && ulc.UserId == request.UserId
                        && ulc.IsActive && !ulc.IsDeleted, cancellationToken);

                if (ulc is null)
                    throw new NotFoundException("Contexto de aprendizaje no encontrado");

                var syllabusUnit = await _context.SyllabusUnits
                    .FirstOrDefaultAsync(su =>
                        su.Slug == request.UnitSlug
                        && su.SyllabusId == ulc.SyllabusId
                        && su.IsActive && !su.IsDeleted, cancellationToken);

                if (syllabusUnit is null)
                    throw new NotFoundException("Unidad no encontrada");

                var progress = await _syllabusProgressRepository.GetByLearningContextAsync(request.UserLearningContextId);
                if (progress is not null)
                {
                    var unitProgress = await _unitProgressRepository.GetByProgressAndUnitAsync(progress.Id, syllabusUnit.Id);

                    if (unitProgress is not null)
                    {
                        unitProgress.MarkUnitExamCompleted(attempt.Score);

                        if (passed)
                            unitProgress.SetStatusApproved();

                        unitProgress.SetUpdated(request.UserId);
                        await _unitProgressRepository.UpdateAsync(unitProgress);

                        await _mediator.Publish(
                            new Users.Events.UnitProgressUpdatedEvent(
                                request.UserId,
                                ulc.SyllabusId,
                                request.UserLearningContextId
                            ), cancellationToken);
                    }
                }
            }
            else if (assessment.Scope == AssessmentScope.SYLLABUS)
            {
                var progress = await _syllabusProgressRepository.GetByLearningContextAsync(request.UserLearningContextId);
                if (progress is not null)
                {
                    progress.MarkFinalExamCompleted(attempt.Score);
                    progress.SetUpdated(request.UserId);
                    await _syllabusProgressRepository.UpdateAsync(progress);
                }
            }

            if (starsEarned > 0)
            {
                var leaderboard = await _leaderboardRepository.GetByUserIdAsync(request.UserId);
                if (leaderboard is not null)
                {
                    leaderboard.AddStars(starsEarned);
                    await _leaderboardRepository.UpdateAsync(leaderboard);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            return new SubmitAssessmentAnswersResponse
            {
                AttemptId = attempt.Id,
                AssessmentId = assessment.Id,
                TotalQuestions = attempt.TotalQuestions,
                CorrectAnswers = attempt.CorrectAnswers,
                Score = attempt.Score,
                StarsEarned = attempt.StarsEarned,
                FinishedAt = attempt.FinishedAt,
                Passed = passed,
                Recommendations = recommendations
            };
        }
    }
}
