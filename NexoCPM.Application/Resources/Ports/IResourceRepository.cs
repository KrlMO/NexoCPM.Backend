using NexoCPM.Application.Commons.Dtos;
using NexoCPM.Domain.Resources.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Resources.Ports
{
    public interface IResourceRepository
    {
        Task<PaginatedResult<Resource>> GetBySubtopicAsync(int subtopicId, int page, int pageSize);
        Task<Resource> AddAsync(string title, string url, string? description, int? subTopicId, int userId);
    }
}
