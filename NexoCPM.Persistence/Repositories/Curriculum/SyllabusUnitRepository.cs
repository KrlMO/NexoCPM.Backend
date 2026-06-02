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

        public async Task<UserSyllabusUnitData?> GetUnitDetailAsync(int syllabusUnitId, int userSyllabusProgressId, int userId)
        {
            var unit = await _context.SyllabusUnits
                .AsNoTracking()
                .Where(su => su.Id == syllabusUnitId && su.IsActive && !su.IsDeleted)
                .Select(su => new
                {
                    su.Id,
                    su.Name,
                    UnitProgressId = su.UserSyllabusUnitProgresses
                        .Where(usup => usup.UserSyllabusProgressId == userSyllabusProgressId)
                        .Select(usup => (int?)usup.Id)
                        .FirstOrDefault(),
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

            var viewedSet = new HashSet<int>();
            if (unit.UnitProgressId.HasValue)
            {
                var viewedIds = await _context.UserSubTopicViews
                    .AsNoTracking()
                    .Where(ustv =>
                        ustv.UserSyllabusUnitProgressId == unit.UnitProgressId.Value
                        && ustv.ViewedAt != default)
                    .Select(ustv => ustv.SubTopicId)
                    .ToListAsync();

                viewedSet = viewedIds.ToHashSet();
            }

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

        public async Task<List<UserSyllabusTopicData>> GetUnitTopicsAsync(int syllabusUnitId, int userSyllabusProgressId, int userId)
        {
            var unitProgressId = await _context.SyllabusUnits
                .AsNoTracking()
                .Where(su => su.Id == syllabusUnitId)
                .SelectMany(su => su.UserSyllabusUnitProgresses
                    .Where(usup => usup.UserSyllabusProgressId == userSyllabusProgressId)
                    .Select(usup => (int?)usup.Id))
                .FirstOrDefaultAsync();

            var topics = await _context.SyllabusUnits
                .AsNoTracking()
                .Where(su => su.Id == syllabusUnitId)
                .SelectMany(su => su.Topics
                    .Where(t => t.IsActive && !t.IsDeleted)
                    .OrderBy(t => t.OrderIndex))
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
                .ToListAsync();

            if (!topics.Any()) return new();

            var viewedSet = new HashSet<int>();
            if (unitProgressId.HasValue)
            {
                var allSubTopicIds = topics.SelectMany(t => t.SubTopics.Select(st => st.Id)).ToHashSet();

                var viewedIds = await _context.UserSubTopicViews
                    .AsNoTracking()
                    .Where(ustv =>
                        ustv.UserSyllabusUnitProgressId == unitProgressId.Value
                        && ustv.ViewedAt != default
                        && allSubTopicIds.Contains(ustv.SubTopicId))
                    .Select(ustv => ustv.SubTopicId)
                    .ToListAsync();

                viewedSet = viewedIds.ToHashSet();
            }

            return topics.Select(t => new UserSyllabusTopicData
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
            }).ToList();
        }

        public async Task<List<UserSyllabusSubtopicData>> GetTopicSubtopicsAsync(int topicId, int userSyllabusProgressId, int userId)
        {
            var topic = await _context.SyllabusTopics
                .AsNoTracking()
                .Where(t => t.Id == topicId && t.IsActive && !t.IsDeleted)
                .Select(t => new
                {
                    t.SyllabusUnitId,
                    UnitProgressId = t.SyllabusUnit.UserSyllabusUnitProgresses
                        .Where(usup => usup.UserSyllabusProgressId == userSyllabusProgressId)
                        .Select(usup => (int?)usup.Id)
                        .FirstOrDefault(),
                    SubTopics = t.SubTopics
                        .Where(st => st.IsActive && !st.IsDeleted)
                        .OrderBy(st => st.OrderIndex)
                        .Select(st => new { st.Id, st.Description, st.Slug })
                        .ToList()
                })
                .FirstOrDefaultAsync();

            if (topic is null) return new();

            var subTopicIds = topic.SubTopics.Select(st => st.Id).ToHashSet();
            if (!subTopicIds.Any()) return new();

            var viewedSet = new HashSet<int>();
            if (topic.UnitProgressId.HasValue)
            {
                var viewedIds = await _context.UserSubTopicViews
                    .AsNoTracking()
                    .Where(ustv =>
                        ustv.UserSyllabusUnitProgressId == topic.UnitProgressId.Value
                        && ustv.ViewedAt != default
                        && subTopicIds.Contains(ustv.SubTopicId))
                    .Select(ustv => ustv.SubTopicId)
                    .ToListAsync();

                viewedSet = viewedIds.ToHashSet();
            }

            return topic.SubTopics.Select(st => new UserSyllabusSubtopicData
            {
                Id = st.Id,
                Description = st.Description,
                Slug = st.Slug,
                Viewed = viewedSet.Contains(st.Id)
            }).ToList();
        }
    }
}
