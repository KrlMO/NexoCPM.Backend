using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Queries.GetSubTopicDetail
{
    public record GetSubTopicDetailQuery(string subtopicSlug, int userId, int userLearningId, int page, int pageSize) : IRequest<GetSubTopicDetailResponse>;
}
