using MediatR;
using NexoCPM.Application.Interfaces;
using NexoCPM.Application.Users.Events;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Common.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace NexoCPM.Application.Users.Commands.ToggleSubTopicCompletion
{
    public class ToggleSubTopicCompletionHandler : IRequestHandler<ToggleSubTopicCompletionCommand, ToggleSubTopicCompletionResult>
    {
        private readonly IUserSubTopicViewRepository _userSubTopicViewRepository;
        private readonly IUserLearningContextRepository _userLearningContextRepository;
        private readonly IUserSyllabusProgressRepository _syllabusProgressRepository;
        private readonly IUserSyllabusUnitProgressRepository _unitProgressRepository;
        private readonly IMediator _mediator;
        private readonly IApplicationDbContext _context;

        public ToggleSubTopicCompletionHandler(
            IUserSubTopicViewRepository userSubTopicViewRepository,
            IUserLearningContextRepository userLearningContextRepository,
            IUserSyllabusProgressRepository syllabusProgressRepository,
            IUserSyllabusUnitProgressRepository unitProgressRepository,
            IMediator mediator,
            IApplicationDbContext context)
        {
            _userSubTopicViewRepository = userSubTopicViewRepository;
            _userLearningContextRepository = userLearningContextRepository;
            _syllabusProgressRepository = syllabusProgressRepository;
            _unitProgressRepository = unitProgressRepository;
            _mediator = mediator;
            _context = context;
        }

        public async Task<ToggleSubTopicCompletionResult> Handle(ToggleSubTopicCompletionCommand request, CancellationToken cancellationToken)
        {
            var ulc = await _userLearningContextRepository.GetByIdAsync(request.UserLearningContextId);
            if (ulc is null || ulc.UserId != request.UserId)
                throw new NotFoundException("Contexto de aprendizaje no encontrado");

            var subTopic = await _context.SubTopics
                .AsNoTracking()
                .FirstOrDefaultAsync(st => st.Id == request.SubTopicId && st.IsActive && !st.IsDeleted, cancellationToken);

            if (subTopic is null)
                throw new NotFoundException("Subtema no encontrado");

            var syllabusUnitId = subTopic.TopicId > 0
                ? await _context.SyllabusTopics
                    .AsNoTracking()
                    .Where(t => t.Id == subTopic.TopicId)
                    .Select(t => t.SyllabusUnitId)
                    .FirstOrDefaultAsync(cancellationToken)
                : 0;

            if (syllabusUnitId == 0)
                throw new NotFoundException("Unidad no encontrada para este subtema");

            var progressId = await _userLearningContextRepository.GetProgressIdAsync(request.UserId, request.UserLearningContextId);
            if (progressId is null)
                throw new NotFoundException("Progreso no encontrado");

            var unitProgress = await _unitProgressRepository.GetByProgressAndUnitAsync(progressId.Value, syllabusUnitId);

            if (unitProgress is null)
            {
                var syllabusProgress = await _syllabusProgressRepository.GetByLearningContextAsync(request.UserLearningContextId);
                if (syllabusProgress is null)
                    throw new NotFoundException("Progreso del temario no encontrado");

                unitProgress = new Domain.Users.Entities.UserSyllabusUnitProgress(
                    syllabusProgress.Id,
                    syllabusUnitId,
                    request.UserId);

                var totalSubTopics = await _context.SubTopics
                    .AsNoTracking()
                    .CountAsync(st =>
                        st.Topic.SyllabusUnitId == syllabusUnitId &&
                        st.IsActive && !st.IsDeleted, cancellationToken);

                unitProgress.UpdateContentProgress(0, totalSubTopics);
                unitProgress.SetCreated(request.UserId);
                await _unitProgressRepository.AddAsync(unitProgress);
            }

            await _userSubTopicViewRepository.ToggleCompletionAsync(unitProgress.Id, request.SubTopicId);

            await _mediator.Publish(new SubTopicCompletionToggledEvent(
                request.UserId,
                unitProgress.Id,
                syllabusUnitId,
                request.UserLearningContextId
            ), cancellationToken);

            var isCompleted = await _context.UserSubTopicViews
                .AsNoTracking()
                .Where(ustv => ustv.UserSyllabusUnitProgressId == unitProgress.Id && ustv.SubTopicId == request.SubTopicId)
                .Select(ustv => ustv.IsCompleted)
                .FirstOrDefaultAsync(cancellationToken);

            var updatedSyllabusProgress = await _syllabusProgressRepository.GetByLearningContextAsync(request.UserLearningContextId);
            double syllabusProgressPct = updatedSyllabusProgress?.OverallProgressPercentage ?? 0;
            double unitProgressPct = unitProgress.OverallProgressPercentage;

            return new ToggleSubTopicCompletionResult
            {
                IsCompleted = isCompleted,
                UnitProgressPercentage = unitProgressPct,
                SyllabusProgressPercentage = syllabusProgressPct
            };
        }
    }
}
