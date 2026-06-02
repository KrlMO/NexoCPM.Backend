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
            var unitProgresses = await _context.UserSyllabusUnitProgresses
                .AsNoTracking()
                .Where(usup => usup.UserId == notification.UserId)
                .ToListAsync(cancellationToken);

            var syllabusUnits = await _context.SyllabusUnits
                .AsNoTracking()
                .Where(su => su.SyllabusId == notification.SyllabusId && su.IsActive && !su.IsDeleted)
                .OrderBy(su => su.OrderIndex)
                .Select(su => su.Id)
                .ToListAsync(cancellationToken);

            var totalUnits = syllabusUnits.Count;
            if (totalUnits == 0) return;

            var progressByUnit = unitProgresses
                .Where(up => syllabusUnits.Contains(up.SyllabusUnitId))
                .ToList();

            var completedUnits = progressByUnit.Count(up => up.OverallProgressPercentage >= 100);
            var unitAverage = progressByUnit.Count > 0
                ? progressByUnit.Average(up => up.OverallProgressPercentage)
                : 0.0;

            var progress = await _context.UserSyllabusProgresses
                .Where(usp => usp.SyllabusId == notification.SyllabusId && usp.UserId == notification.UserId)
                .FirstOrDefaultAsync(cancellationToken);

            if (progress is null) return;

            progress.UpdateContentProgress(completedUnits, totalUnits, unitAverage);
            progress.SetUpdated(notification.UserId);
            await _syllabusProgressRepository.UpdateAsync(progress);
        }
    }
}
