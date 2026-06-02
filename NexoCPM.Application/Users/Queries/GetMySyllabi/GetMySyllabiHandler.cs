using MediatR;
using NexoCPM.Application.Commons.Dtos;
using NexoCPM.Application.Users.Dtos;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Users.Enums;

namespace NexoCPM.Application.Users.Queries.GetMySyllabi
{
    public class GetMySyllabiHandler : IRequestHandler<GetMySyllabiQuery, GetMySyllabiResponse>
    {
        private readonly IUserLearningContextRepository _userLearningContext;

        public GetMySyllabiHandler(
                IUserLearningContextRepository userLearningContext    
            )
        { 
            _userLearningContext = userLearningContext;
        }

        public async Task<GetMySyllabiResponse> Handle(GetMySyllabiQuery request, CancellationToken cancellationToken)
        {
            var paged = await _userLearningContext.GetByUserIdPagedAsync(
                request.userId, request.searchTerm, request.sortOrder, request.page, request.pageSize);

            var progressIds = paged.Items
                .Select(ulc => ulc.UserSyllabusProgress!.Id)
                .ToArray();

            var summaries = await _userLearningContext.GetProgressSummariesAsync(progressIds, request.userId);

            var items = paged.Items.Select(ulc =>
            {
                var progress = ulc.UserSyllabusProgress;
                var summary = summaries.GetValueOrDefault(progress!.Id);
                var sumTotal = summary?.TotalSubTopics ?? 0;
                var sumViewed = summary?.ViewedSubTopics ?? 0;
                var percentage = sumTotal > 0
                    ? Math.Round((decimal)sumViewed / sumTotal * 100, 2)
                    : 0m;

                return new MySyllabusDto
                {
                    Id = ulc.Syllabus.Id,
                    Code = ulc.Syllabus.Code,
                    Name = ulc.Syllabus.Name,
                    Slug = ulc.Syllabus.Slug,
                    Status = progress.Status == UserProgressStatus.COMPLETED ? "COMPLETED" : "IN_PROGRESS",
                    LastAccess = DateOnly.FromDateTime(progress.LastAccess),
                    CompletedPercentage = percentage,
                    UserLearningContextId = ulc.Id
                };
            }).ToList();

            return new GetMySyllabiResponse
            {
                MySyllabi = new PaginatedResult<MySyllabusDto>
                {
                    Items = items,
                    TotalCount = paged.TotalCount,
                    Page = paged.Page,
                    PageSize = paged.PageSize
                }
            };
        }
    }
}
