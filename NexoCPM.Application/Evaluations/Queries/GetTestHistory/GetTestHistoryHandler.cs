using MediatR;
using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Evaluations.Dtos;
using NexoCPM.Application.Interfaces;
using NexoCPM.Domain.Common.Exceptions;
using NexoCPM.Domain.Evaluations.Enums;

namespace NexoCPM.Application.Evaluations.Queries.GetTestHistory
{
    public class GetTestHistoryHandler : IRequestHandler<GetTestHistoryQuery, GetTestHistoryResponse>
    {
        private readonly IApplicationDbContext _context;

        public GetTestHistoryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetTestHistoryResponse> Handle(GetTestHistoryQuery request, CancellationToken cancellationToken)
        {
            var ulc = await _context.UserLearningContexts
                .AsNoTracking()
                .FirstOrDefaultAsync(ulc =>
                    ulc.Id == request.UserLearningContextId
                    && ulc.UserId == request.UserId
                    && ulc.IsActive && !ulc.IsDeleted, cancellationToken);

            if (ulc is null)
                throw new NotFoundException("Contexto de aprendizaje no encontrado");

            var syllabus = await _context.Syllabi
                .AsNoTracking()
                .FirstOrDefaultAsync(s =>
                    s.Slug == request.SyllabusSlug
                    && s.Id == ulc.SyllabusId
                    && s.IsActive && !s.IsDeleted, cancellationToken);

            if (syllabus is null)
                throw new NotFoundException("Temario no encontrado");

            AssessmentScope scope;
            int targetId;

            if (!string.IsNullOrWhiteSpace(request.UnitSlug))
            {
                var unit = await _context.SyllabusUnits
                    .AsNoTracking()
                    .FirstOrDefaultAsync(su =>
                        su.Slug == request.UnitSlug
                        && su.SyllabusId == syllabus.Id
                        && su.IsActive && !su.IsDeleted, cancellationToken);

                if (unit is null)
                    throw new NotFoundException("Unidad no encontrada");

                scope = AssessmentScope.UNIT;
                targetId = unit.Id;
            }
            else
            {
                scope = AssessmentScope.SYLLABUS;
                targetId = syllabus.Id;
            }

            var assessment = await _context.Assessments
                .AsNoTracking()
                .FirstOrDefaultAsync(a =>
                    a.Scope == scope
                    && a.TargetId == targetId
                    && a.Type == AssessmentType.KNOLEDGE
                    && a.IsActive, cancellationToken);

            if (assessment is null)
                throw new NotFoundException("Prueba no encontrada para este contenido");

            var attempts = await _context.AssessmentAttempts
                .AsNoTracking()
                .Where(aa =>
                    aa.AssessmentId == assessment.Id
                    && aa.UserLearningContextId == request.UserLearningContextId
                    && aa.Status == AssessmentAttemptStatus.COMPLETED)
                .OrderByDescending(aa => aa.FinishedAt)
                .Select(aa => new TestHistoryDto
                {
                    AttemptId = aa.Id,
                    FinishedAt = aa.FinishedAt,
                    Passed = aa.Score >= 60,
                    Score = aa.Score,
                    StarsEarned = aa.StarsEarned,
                    TotalQuestions = aa.TotalQuestions,
                    CorrectAnswers = aa.CorrectAnswers
                })
                .ToListAsync(cancellationToken);

            return new GetTestHistoryResponse { History = attempts };
        }
    }
}
