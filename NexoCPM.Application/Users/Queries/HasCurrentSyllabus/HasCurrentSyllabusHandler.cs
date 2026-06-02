using MediatR;
using NexoCPM.Application.Interfaces;
using NexoCPM.Application.Users.Ports;
using Microsoft.EntityFrameworkCore;
using NexoCPM.Domain.Users.Enums;

namespace NexoCPM.Application.Users.Queries.HasCurrentSyllabus
{
    public class HasCurrentSyllabusHandler : IRequestHandler<HasCurrentSyllabusQuery, HasCurrentSyllabusRespone>
    {
        private readonly IUserLearningContextRepository _userLearningContextRepository;
        private readonly IApplicationDbContext _context;

        public HasCurrentSyllabusHandler(
            IUserLearningContextRepository userLearningContextRepository,
            IApplicationDbContext context)
        {
            _userLearningContextRepository = userLearningContextRepository;
            _context = context;
        }

        public async Task<HasCurrentSyllabusRespone> Handle(HasCurrentSyllabusQuery request, CancellationToken cancellationToken)
        {
            var ulc = await _userLearningContextRepository.GetByUserAndSyllabusSlugAsync(request.userId, request.syllabusSlug);

            if (ulc?.UserSyllabusProgress is null || ulc.UserSyllabusProgress.Status == UserProgressStatus.COMPLETED)
                return new HasCurrentSyllabusRespone { HasCurrent = false };

            var progress = ulc.UserSyllabusProgress;
            var syllabusId = ulc.SyllabusId;

            var totalSubTopics = await _context.SubTopics
                .AsNoTracking()
                .CountAsync(st => st.IsActive && !st.IsDeleted
                    && st.Topic.SyllabusUnit.SyllabusId == syllabusId, cancellationToken);

            var unitProgressIds = await _context.UserSyllabusUnitProgresses
                .AsNoTracking()
                .Where(usup => usup.UserSyllabusProgressId == progress.Id)
                .Select(usup => usup.Id)
                .ToListAsync(cancellationToken);

            var viewedSubTopics = unitProgressIds.Count > 0
                ? await _context.UserSubTopicViews
                    .AsNoTracking()
                    .CountAsync(ustv =>
                        unitProgressIds.Contains(ustv.UserSyllabusUnitProgressId)
                        && ustv.ViewedAt != default, cancellationToken)
                : 0;

            var percentage = totalSubTopics > 0
                ? Math.Round((decimal)viewedSubTopics / totalSubTopics * 100, 2)
                : 0m;

            return new HasCurrentSyllabusRespone
            {
                HasCurrent = true,
                Percentage = percentage,
                UserLearningContextId = ulc.Id,
                LastAccess = DateOnly.FromDateTime(progress.LastAccess)
            };
        }
    }
}
