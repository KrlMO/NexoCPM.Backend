using NexoCPM.Application.Commons.Dtos;
using NexoCPM.Application.Resources.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Resources.Queries
{
    public class GetResourcesBySubtopicResponse
    {
        public PaginatedResult<ResourceDto> Resources { get; set; } = default!;
    }
}
