using MediatR;
using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Interfaces;
using NexoCPM.Application.Users.Ports;

namespace NexoCPM.Application.Users.Events
{
    public class UpdateUnitProgressHandler : INotificationHandler<SubTopicCompletionToggledEvent>
    {
        private readonly IUserSyllabusProgressRepository _syllabusProgressRepository;
        private readonly IUserSyllabusUnitProgressRepository _unitProgressRepository;
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;

        public UpdateUnitProgressHandler(
            IUserSyllabusProgressRepository syllabusProgressRepository,
            IUserSyllabusUnitProgressRepository unitProgressRepository,
            IApplicationDbContext context,
            IMediator mediator)
        {
            _syllabusProgressRepository = syllabusProgressRepository;
            _unitProgressRepository = unitProgressRepository;
            _context = context;
            _mediator = mediator;
        }

        public async Task Handle(SubTopicCompletionToggledEvent notification, CancellationToken cancellationToken)
        {
            var progress = await _syllabusProgressRepository.GetByLearningContextAsync(notification.UserLearningContextId);
            if (progress is null) return;

            var unitProgress = await _unitProgressRepository.GetByProgressAndUnitAsync(progress.Id, notification.SyllabusUnitId);
            if (unitProgress is null) return;

            var totalSubTopics = await _context.SubTopics
                .AsNoTracking()
                .CountAsync(st =>
                    st.Topic.SyllabusUnitId == notification.SyllabusUnitId &&
                    st.IsActive && !st.IsDeleted, cancellationToken);

            var completedSubTopics = await _context.UserSubTopicViews
                .AsNoTracking()
                .CountAsync(ustv =>
                    ustv.UserSyllabusUnitProgressId == notification.UserSyllabusUnitProgressId &&
                    ustv.IsCompleted, cancellationToken);

            unitProgress.UpdateContentProgress(completedSubTopics, totalSubTopics);
            unitProgress.SetUpdated(notification.UserId);
            await _unitProgressRepository.UpdateAsync(unitProgress);

            await _mediator.Publish(new UnitProgressUpdatedEvent(
                notification.UserId,
                progress.SyllabusId
            ), cancellationToken);
        }
    }
}
