using MediatR;
using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Interfaces;
using NexoCPM.Domain.Common.Exceptions;

namespace NexoCPM.Application.Evaluations.Queries.GetSimulationModes
{
    public class GetSimulationModesHandler : IRequestHandler<GetSimulationModesQuery, GetSimulationModesResponse>
    {
        private readonly IApplicationDbContext _context;

        public GetSimulationModesHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetSimulationModesResponse> Handle(GetSimulationModesQuery request, CancellationToken cancellationToken)
        {
            var assessment = await _context.Assessments
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == request.AssessmentId && a.IsActive, cancellationToken);

            if (assessment is null)
                throw new NotFoundException("Simulacro no encontrado");

            if (assessment.TargetId is null)
            {
                return new GetSimulationModesResponse { HasHistoricalData = false };
            }

            var hasHistoricalData = await HasWrongAnswersInSyllabus(request.UserId, assessment.TargetId.Value, cancellationToken);

            return new GetSimulationModesResponse { HasHistoricalData = hasHistoricalData };
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
