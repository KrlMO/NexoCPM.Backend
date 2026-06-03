using MediatR;
using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Evaluations.Dtos;
using NexoCPM.Application.Interfaces;
using NexoCPM.Domain.Common.Exceptions;
using NexoCPM.Domain.Evaluations.Enums;

namespace NexoCPM.Application.Evaluations.Queries.GetTestInfo
{
    public class GetTestInfoHandler : IRequestHandler<GetTestInfoQuery, GetTestInfoResponse>
    {
        private readonly IApplicationDbContext _context;

        public GetTestInfoHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetTestInfoResponse> Handle(GetTestInfoQuery request, CancellationToken cancellationToken)
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
            string title;
            string unitName;

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
                unitName = unit.Name;
                title = $"Prueba de unidad: {unit.Name}";
            }
            else
            {
                scope = AssessmentScope.SYLLABUS;
                targetId = syllabus.Id;
                unitName = syllabus.Name;
                title = $"Prueba de fin de temario: {syllabus.Name}";
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

            var attemptsUsed = await _context.AssessmentAttempts
                .CountAsync(aa =>
                    aa.AssessmentId == assessment.Id
                    && aa.UserLearningContextId == request.UserLearningContextId, cancellationToken);

            var maxAttempts = assessment.MaxAttempts ?? 1;

            return new GetTestInfoResponse
            {
                Test = new TestInfoDto
                {
                    AssessmentId = assessment.Id,
                    Code = assessment.Code,
                    Title = title,
                    Scope = scope.ToString(),
                    TargetId = targetId,
                    NumberQuestions = assessment.NumberQuestions,
                    TimeLimitSeconds = assessment.TimeLimitSeconds,
                    MaxAttempts = maxAttempts,
                    AttemptsUsed = attemptsUsed,
                    AttemptsRemaining = Math.Max(0, maxAttempts - attemptsUsed)
                }
            };
        }
    }
}
