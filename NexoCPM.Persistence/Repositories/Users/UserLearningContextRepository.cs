using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Commons.Dtos;
using NexoCPM.Application.Users.Dtos;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Users.Entities;
using NexoCPM.Domain.Users.Enums;
using NexoCPM.Persistence.Context;

namespace NexoCPM.Persistence.Repositories.Users
{
    public class UserLearningContextRepository : IUserLearningContextRepository
    {
        private readonly ApplicationDbContext _context;

        public UserLearningContextRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserLearningContext?> GetByIdAsync(int id)
        {
            return await _context.UserLearningContexts
                .AsNoTracking()
                .FirstOrDefaultAsync(ulc => ulc.Id == id && ulc.IsActive && !ulc.IsDeleted);
        }

        public async Task<UserLearningContext?> GetByUserAndSyllabusSlugAsync(int userId, string syllabusSlug)
        {
            return await _context.UserLearningContexts
                .AsNoTracking()
                .Include(ulc => ulc.Syllabus)
                .Include(ulc => ulc.UserSyllabusProgress)
                    .ThenInclude(usp => usp.UserSyllabusUnitProgresses)
                        .ThenInclude(usup => usup.SyllabusUnit)
                            .ThenInclude(su => su.Topics)
                                .ThenInclude(t => t.SubTopics)
                .FirstOrDefaultAsync(ulc =>
                    ulc.UserId == userId &&
                    ulc.Syllabus.Slug == syllabusSlug &&
                    ulc.IsActive &&
                    !ulc.IsDeleted);
        }

        public async Task<UserLearningContext?> GetByUserAndSyllabusSlugTrackedAsync(int userId, string syllabusSlug)
        {
            return await _context.UserLearningContexts
                .Include(ulc => ulc.Syllabus)
                .Include(ulc => ulc.UserSyllabusProgress)
                .FirstOrDefaultAsync(ulc =>
                    ulc.UserId == userId &&
                    ulc.Syllabus.Slug == syllabusSlug &&
                    ulc.IsActive &&
                    !ulc.IsDeleted);
        }

        public async Task<UserLearningContext> AddAsync(UserLearningContext userLearningContext)
        {
            _context.UserLearningContexts.Add(userLearningContext);
            await _context.SaveChangesAsync();
            return userLearningContext;
        }

        public async Task<int?> GetProgressIdAsync(int userId, int userLearningContextId)
        {
            return await _context.UserLearningContexts
                .AsNoTracking()
                .Where(ulc => ulc.Id == userLearningContextId && ulc.UserId == userId && ulc.IsActive && !ulc.IsDeleted && ulc.UserSyllabusProgress != null)
                .Select(ulc => (int?)ulc.UserSyllabusProgress!.Id)
                .FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<PaginatedResult<UserLearningContext>> GetByUserIdPagedAsync(int userId, string? searchTerm, string sortOrder, int page, int pageSize)
        {
            var query = _context.UserLearningContexts
                .AsNoTracking()
                .Include(ulc => ulc.Syllabus)
                .Include(ulc => ulc.UserSyllabusProgress)
                .Where(ulc => ulc.UserId == userId && ulc.IsActive && !ulc.IsDeleted && ulc.UserSyllabusProgress != null);

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(ulc =>
                    ulc.Syllabus.Name.Contains(searchTerm) ||
                    ulc.Syllabus.Code.Contains(searchTerm));
            }

            var totalCount = await query.CountAsync();

            query = sortOrder?.ToLower() == "asc"
                ? query.OrderBy(ulc => ulc.UserSyllabusProgress!.LastAccess)
                : query.OrderByDescending(ulc => ulc.UserSyllabusProgress!.LastAccess);

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedResult<UserLearningContext>
            {
                Items = items,
                TotalCount = totalCount,
                Page = page,
                PageSize = pageSize
            };
        }

        public async Task<UserSyllabusDetailData?> GetDetailAsync(int userId, int userLearningContextId, string syllabusSlug)
        {
            var ulc = await _context.UserLearningContexts
                .AsNoTracking()
                .Include(ulc => ulc.Syllabus)
                .Include(ulc => ulc.UserSyllabusProgress)
                .FirstOrDefaultAsync(ulc =>
                    ulc.Id == userLearningContextId &&
                    ulc.UserId == userId &&
                    ulc.Syllabus.Slug == syllabusSlug &&
                    ulc.IsActive && !ulc.IsDeleted);

            if (ulc is null || ulc.UserSyllabusProgress is null) return null;

            var syllabusId = ulc.SyllabusId;
            var progress = ulc.UserSyllabusProgress;

            var units = await _context.SyllabusUnits
                .AsNoTracking()
                .Where(su => su.SyllabusId == syllabusId && su.IsActive && !su.IsDeleted)
                .OrderBy(su => su.OrderIndex)
                .Select(su => new
                {
                    su.Id,
                    su.Name,
                    su.Slug,
                    Status = su.UserSyllabusUnitProgresses
                        .Where(usup => usup.UserSyllabusProgressId == progress!.Id)
                        .Select(usup => usup.Status)
                        .FirstOrDefault()
                })
                .ToListAsync();

            var totalSubTopics = await _context.SubTopics
                .AsNoTracking()
                .CountAsync(st => st.Topic.SyllabusUnit.SyllabusId == syllabusId
                    && st.IsActive && !st.IsDeleted);

            var unitProgressIdsForSyllabus = await _context.UserSyllabusUnitProgresses
                .AsNoTracking()
                .Where(usup => usup.UserSyllabusProgressId == progress!.Id)
                .Select(usup => usup.Id)
                .ToListAsync();

            var viewedSubTopics = unitProgressIdsForSyllabus.Count > 0
                ? await _context.UserSubTopicViews
                    .AsNoTracking()
                    .CountAsync(ustv =>
                        unitProgressIdsForSyllabus.Contains(ustv.UserSyllabusUnitProgressId)
                        && ustv.ViewedAt != default)
                : 0;

            var percentage = totalSubTopics > 0
                ? Math.Round((decimal)viewedSubTopics / totalSubTopics * 100, 2)
                : 0m;

            return new UserSyllabusDetailData
            {
                Id = ulc.Syllabus.Id,
                Name = ulc.Syllabus.Name,
                Slug = ulc.Syllabus.Slug,
                Code = ulc.Syllabus.Code,
                LastAccess = DateOnly.FromDateTime(progress!.LastAccess),
                CompletedPercentage = percentage,
                Status = progress.Status == UserProgressStatus.COMPLETED ? "COMPLETED" : "IN_PROGRESS",
                units = units.Select(u => new UserSyllabusUnitData
                {
                    Id = u.Id,
                    Name = u.Name,
                    Status = u.Status == 0 ? "LOCKED" : u.Status.ToString(),
                    Slug = u.Slug,
                    topics = null
                }).ToList()
            };
        }

        public async Task<Dictionary<int, ProgressSummary>> GetProgressSummariesAsync(int[] userSyllabusProgressIds, int userId)
        {
            if (userSyllabusProgressIds.Length == 0)
                return new();

            var data = await _context.UserSyllabusUnitProgresses
                .AsNoTracking()
                .Where(usup => userSyllabusProgressIds.Contains(usup.UserSyllabusProgressId))
                .Select(usup => new
                {
                    usup.Id,
                    usup.UserSyllabusProgressId,
                    usup.SyllabusUnitId,
                    TotalSubTopics = usup.SyllabusUnit.Topics
                        .SelectMany(t => t.SubTopics)
                        .Count(st => st.IsActive && !st.IsDeleted),
                })
                .GroupBy(x => x.UserSyllabusProgressId)
                .Select(g => new
                {
                    UserSyllabusProgressId = g.Key,
                    SumTotal = g.Sum(x => x.TotalSubTopics),
                    UnitProgressIds = g.Select(x => x.Id).ToList(),
                    SyllabusUnitIds = g.Select(x => x.SyllabusUnitId).ToList()
                })
                .ToListAsync();

            var unitProgressIds = data.SelectMany(d => d.UnitProgressIds).Distinct().ToHashSet();

            var viewedByUnitProgress = new Dictionary<int, int>();
            if (unitProgressIds.Any())
            {
                viewedByUnitProgress = await _context.UserSubTopicViews
                    .AsNoTracking()
                    .Where(ustv =>
                        unitProgressIds.Contains(ustv.UserSyllabusUnitProgressId)
                        && ustv.ViewedAt != default)
                    .GroupBy(ustv => ustv.UserSyllabusUnitProgressId)
                    .Select(g => new { UserSyllabusUnitProgressId = g.Key, Count = g.Count() })
                    .ToDictionaryAsync(x => x.UserSyllabusUnitProgressId, x => x.Count);
            }

            var progressViewedByProgress = data.ToDictionary(
                x => x.UserSyllabusProgressId,
                x => x.UnitProgressIds.Sum(upId => viewedByUnitProgress.GetValueOrDefault(upId, 0)));

            return data.ToDictionary(
                x => x.UserSyllabusProgressId,
                x => new ProgressSummary
                {
                    TotalSubTopics = x.SumTotal,
                    ViewedSubTopics = progressViewedByProgress.GetValueOrDefault(x.UserSyllabusProgressId, 0)
                });
        }
    }
}
