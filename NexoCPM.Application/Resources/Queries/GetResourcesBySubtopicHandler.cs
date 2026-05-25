using MediatR;
using NexoCPM.Application.Commons.Dtos;
using NexoCPM.Application.Resources.Dtos;
using NexoCPM.Application.Resources.Ports;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Resources.Queries
{
    public class GetResourcesBySubtopicHandler : IRequestHandler<GetResourcesBySubtopicQuery, GetResourcesBySubtopicResponse>
    {
        public readonly IResourceRepository _resourceRepository;
        public GetResourcesBySubtopicHandler(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }
        public async Task<GetResourcesBySubtopicResponse> Handle(GetResourcesBySubtopicQuery request, CancellationToken cancellationToken)
        {
            var paged = await _resourceRepository.GetBySubtopicAsync(request.SubtopicId, request.Page, request.PageSize);

            var Items = paged.Items.Select(r => new ResourceDto
            {
                Id = r.Id,
                Title = r.Title,
                Url = r.Url,
                Description = r.Description,
                LikesCount = r.LikesCount
            }).ToList();

            return new GetResourcesBySubtopicResponse
            {
                Resources = new PaginatedResult<ResourceDto>
                {
                    Items = Items,
                    TotalCount = paged.TotalCount,
                    Page = paged.Page,
                    PageSize = paged.PageSize
                }
            };
        }
    }
}
