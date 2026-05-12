using MediatR;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Users.Enums;

namespace NexoCPM.Application.Users.Queries.HasCurrentSyllabus
{
    public class HasCurrentSyllabusHandler : IRequestHandler<HasCurrentSyllabusQuery, HasCurrentSyllabusRespone>
    {
        private readonly IUserLearningContextRepository _userLearningContextRepository;

        public HasCurrentSyllabusHandler(
            IUserLearningContextRepository userLearningContextRepository)
        {
            _userLearningContextRepository = userLearningContextRepository;
        }

        public async Task<HasCurrentSyllabusRespone> Handle(HasCurrentSyllabusQuery request, CancellationToken cancellationToken)
        {
            var ulc = await _userLearningContextRepository.GetByUserAndSyllabusSlugAsync(request.userId, request.syllabusSlug);

            if (ulc?.UserSyllabusProgress is null || ulc.UserSyllabusProgress.Status == UserProgressStatus.COMPLETED)
                return new HasCurrentSyllabusRespone { HasCurrent = false };

            var progress = ulc.UserSyllabusProgress;

            var unitData = progress.UserSyllabusUnitProgresses
                .Select(usup => new
                {
                    TotalSubTopics = usup.SyllabusUnit.Topics
                        .SelectMany(t => t.SubTopics)
                        .Count(),
                    ViewedSubTopics = usup.UserSubTopicViews
                        .Count(ustv => ustv.IsViewed)
                })
                .ToList();

            var sumTotal = unitData.Sum(u => u.TotalSubTopics);
            var sumViewed = unitData.Sum(u => u.ViewedSubTopics);

            var percentage = sumTotal > 0
                ? Math.Round((decimal)sumViewed / sumTotal * 100, 2)
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
