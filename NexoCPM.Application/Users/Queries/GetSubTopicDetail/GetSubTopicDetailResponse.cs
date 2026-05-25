using NexoCPM.Application.Commons.Dtos;
using NexoCPM.Application.Curriculum.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Queries.GetSubTopicDetail
{
    public class GetSubTopicDetailResponse
    {
        public PaginatedResult<SubTopicDetailDto> SubTopicDetail { get; set; } = new PaginatedResult<SubTopicDetailDto>();
    }
}
