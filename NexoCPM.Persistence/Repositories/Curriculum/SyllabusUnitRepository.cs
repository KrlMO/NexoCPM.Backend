using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Curriculum.Ports;
using NexoCPM.Application.Users.Dtos;
using NexoCPM.Domain.Users.Enums;
using NexoCPM.Persistence.Context;

namespace NexoCPM.Persistence.Repositories.Curriculum
{
    public class SyllabusUnitRepository : ISyllabusUnitRepository
    {
        private readonly ApplicationDbContext _context;

        public SyllabusUnitRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserSyllabusUnitData?> GetUnitDetailAsync(int syllabusUnitId, int userSyllabusProgressId)
        {
            var unit = await _context.SyllabusUnits
                .AsNoTracking()
                .Where(su => su.Id == syllabusUnitId && su.IsActive && !su.IsDeleted)
                .Select(su => new
                {
                    su.Id,
                    su.Name,
                    Status = su.UserSyllabusUnitProgresses
                        .Where(usup => usup.UserSyllabusProgressId == userSyllabusProgressId)
                        .Select(usup => usup.Status)
                        .FirstOrDefault(),
                    Topics = su.Topics
                        .Where(t => t.IsActive && !t.IsDeleted)
                        .OrderBy(t => t.OrderIndex)
                        .Select(t => new
                        {
                            t.Id,
                            t.Description,
                            t.Slug,
                            SubTopics = t.SubTopics
                                .Where(st => st.IsActive && !st.IsDeleted)
                                .OrderBy(st => st.OrderIndex)
                                .Select(st => new { st.Id, st.Description, st.Slug })
                                .ToList()
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();

            if (unit is null) return null;

            var viewedIds = await _context.UserSubTopicViews
                .AsNoTracking()
                .Where(ustv =>
                    ustv.UserSyllabusUnitProgress.UserSyllabusProgressId == userSyllabusProgressId
                    && ustv.UserSyllabusUnitProgress.SyllabusUnitId == syllabusUnitId
                    && ustv.IsViewed)
                .Select(ustv => ustv.SubTopicId)
                .ToListAsync();

            var viewedSet = viewedIds.ToHashSet();

            return new UserSyllabusUnitData
            {
                Id = unit.Id,
                Name = unit.Name,
                Status = unit.Status == 0 ? "LOCKED" : unit.Status.ToString(),
                topics = unit.Topics.Select(t => new UserSyllabusTopicData
                {
                    Id = t.Id,
                    Description = t.Description,
                    Slug = t.Slug,
                    Viewed = t.SubTopics.Count > 0 && t.SubTopics.All(st => viewedSet.Contains(st.Id)),
                    SubTopics = t.SubTopics.Select(st => new UserSyllabusSubtopicData
                    {
                        Id = st.Id,
                        Description = st.Description,
                        Slug = st.Slug,
                        Viewed = viewedSet.Contains(st.Id)
                    }).ToList()
                }).ToList()
            };
        }
    }
}
