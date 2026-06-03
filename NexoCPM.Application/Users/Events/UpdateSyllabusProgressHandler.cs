using MediatR;
using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Interfaces;
using NexoCPM.Application.Users.Ports;

namespace NexoCPM.Application.Users.Events
{
    public class UpdateSyllabusProgressHandler : INotificationHandler<UnitProgressUpdatedEvent>
    {
        private readonly IUserSyllabusProgressRepository _syllabusProgressRepository;
        private readonly IApplicationDbContext _context;

        public UpdateSyllabusProgressHandler(
            IUserSyllabusProgressRepository syllabusProgressRepository,
            IApplicationDbContext context)
        {
            _syllabusProgressRepository = syllabusProgressRepository;
            _context = context;
        }

        public async Task Handle(UnitProgressUpdatedEvent notification, CancellationToken cancellationToken)
        {
            var progress = await _context.UserSyllabusProgresses
                .Include(usp => usp.UserLearningContext)
                .FirstOrDefaultAsync(usp => usp.UserLearningContextId == notification.UserLearningContextId, cancellationToken);

            if (progress is null) return;

            var syllabusId = progress.UserLearningContext.SyllabusId;

            var syllabusUnits = await _context.SyllabusUnits
                .AsNoTracking()
                .Where(su => su.SyllabusId == syllabusId && su.IsActive && !su.IsDeleted)
                .OrderBy(su => su.OrderIndex)
                .Select(su => su.Id)
                .ToListAsync(cancellationToken);

            var totalUnits = syllabusUnits.Count;
            if (totalUnits == 0) return;

            var unitProgresses = await _context.UserSyllabusUnitProgresses
                .AsNoTracking()
                .Where(usup => usup.UserSyllabusProgressId == progress.Id)
                .ToListAsync(cancellationToken);

            var completedUnits = unitProgresses.Count(up => up.OverallProgressPercentage >= 100);
            var unitAverage = unitProgresses.Count > 0
                ? unitProgresses.Average(up => up.OverallProgressPercentage)
                : 0.0;

            progress.UpdateContentProgress(completedUnits, totalUnits, unitAverage);
            progress.SetUpdated(notification.UserId);
            await _syllabusProgressRepository.UpdateAsync(progress);
        }
    }
}
