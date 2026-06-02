using Microsoft.EntityFrameworkCore;        

using NexoCPM.Application.Commons.Dtos;
using NexoCPM.Application.Resources.Ports;
using NexoCPM.Domain.Resources.Entities;
using NexoCPM.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Repositories.Resources
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly ApplicationDbContext _context;
        public ResourceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PaginatedResult<Resource>> GetBySubtopicAsync(int subtopicId, int page, int pageSize)
        {
            var query = _context.Resources
                .Where(r => r.SubTopicId == subtopicId && !r.IsDeleted && r.IsActive)
                .OrderByDescending(r => r.LikesCount)
                .ThenByDescending(r => r.ViewsCount);

            var totalCount = await query.CountAsync();

            var items = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedResult<Resource>
            {
                Items = items,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }

        public async Task<Resource> AddAsync(string title, string url, string? description, int? subTopicId, int userId)
        {
            var resource = new Resource();
            _context.Resources.Add(resource);
            var e = _context.Entry(resource);
            e.Property(r => r.Title).CurrentValue = title;
            e.Property(r => r.Url).CurrentValue = url;
            e.Property(r => r.Description).CurrentValue = description ?? string.Empty;
            e.Property(r => r.SubTopicId).CurrentValue = subTopicId;
            e.Property(r => r.IsActive).CurrentValue = true;
            resource.SetCreated(userId);
            await _context.SaveChangesAsync();
            return resource;
        }
    }
}
