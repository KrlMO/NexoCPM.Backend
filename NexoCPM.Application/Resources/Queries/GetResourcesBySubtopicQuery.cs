using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Resources.Queries
{
    public record GetResourcesBySubtopicQuery(int SubtopicId, int Page, int PageSize) : IRequest<GetResourcesBySubtopicResponse>;
}
