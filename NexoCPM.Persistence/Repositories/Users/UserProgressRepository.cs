using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Commons.Dtos;
using NexoCPM.Application.Users.Dtos;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Evaluations.Enums;
using NexoCPM.Persistence.Context;

namespace NexoCPM.Persistence.Repositories.Users;

public class UserProgressRepository : IUserProgressRepository
{
    private readonly ApplicationDbContext _context;

    public UserProgressRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SyllabusProgressDto>> GetSyllabiProgressAsync(int userId)
    {
        var contexts = await _context.UserLearningContexts
            .AsNoTracking()
            .Where(ulc => ulc.UserId == userId && ulc.IsActive && !ulc.IsDeleted && ulc.UserSyllabusProgress != null)
            .OrderByDescending(ulc => ulc.UserSyllabusProgress!.LastAccess)
            .Select(ulc => new
            {
                UserLearningContextId = ulc.Id,
                UserSyllabusProgressId = ulc.UserSyllabusProgress!.Id,
                SyllabusName = ulc.Syllabus.Name,
                SyllabusSlug = ulc.Syllabus.Slug,
                SyllabusId = ulc.SyllabusId,
            })
            .ToListAsync();

        var syllabusIds = contexts.Select(c => c.SyllabusId).Distinct().ToHashSet();
        var progressIds = contexts.Select(c => c.UserSyllabusProgressId).ToHashSet();

        var subtopicCountsBySyllabus = await _context.SubTopics
            .AsNoTracking()
            .Where(st => st.IsActive && !st.IsDeleted && syllabusIds.Contains(st.Topic.SyllabusUnit.SyllabusId))
            .GroupBy(st => st.Topic.SyllabusUnit.SyllabusId)
            .Select(g => new { SyllabusId = g.Key, Count = g.Count() })
            .ToListAsync();

        var totalBySyllabus = subtopicCountsBySyllabus.ToDictionary(x => x.SyllabusId, x => x.Count);

        var viewedByProgress = await _context.UserSubTopicViews
            .AsNoTracking()
            .Where(ustv =>
                ustv.ViewedAt != default
                && progressIds.Contains(ustv.UserSyllabusUnitProgress.UserSyllabusProgressId))
            .GroupBy(ustv => ustv.UserSyllabusUnitProgress.UserSyllabusProgressId)
            .Select(g => new { UserSyllabusProgressId = g.Key, Count = g.Count() })
            .ToListAsync();

        var progressToSyllabus = contexts.ToDictionary(c => c.UserSyllabusProgressId, c => c.SyllabusId);
        var viewedBySyllabusDict = viewedByProgress
            .GroupBy(v => progressToSyllabus.GetValueOrDefault(v.UserSyllabusProgressId, 0))
            .ToDictionary(g => g.Key, g => g.Sum(v => v.Count));

        return contexts.Select(c =>
        {
            var sumTotal = totalBySyllabus.GetValueOrDefault(c.SyllabusId, 0);
            var sumViewed = viewedBySyllabusDict.GetValueOrDefault(c.SyllabusId, 0);

            return new SyllabusProgressDto
            {
                UserLearningContextId = c.UserLearningContextId,
                UserSyllabusProgressId = c.UserSyllabusProgressId,
                SyllabusName = c.SyllabusName,
                SyllabusSlug = c.SyllabusSlug,
                CompletedPercentage = sumTotal > 0
                    ? Math.Round((decimal)sumViewed / sumTotal * 100, 2)
                    : 0m
            };
        }).ToList();
    }

    public async Task<List<DashboardSyllabusDto>> GetActiveSyllabusProgressAsync(int userId)
    {
        var contexts = await _context.UserLearningContexts
            .AsNoTracking()
            .Where(ulc => ulc.UserId == userId && ulc.IsActive && !ulc.IsDeleted && ulc.UserSyllabusProgress != null)
            .OrderByDescending(ulc => ulc.UserSyllabusProgress!.LastAccess)
            .Take(4)
            .Select(ulc => new
            {
                SyllabusId = ulc.Syllabus.Id,
                SyllabusCode = ulc.Syllabus.Code,
                SyllabusName = ulc.Syllabus.Name,
                Slug = ulc.Syllabus.Slug,
                Modality = ulc.Syllabus.SyllabusContexts
                    .Select(sc => sc.EducationContext.Level.Modality.Name)
                    .FirstOrDefault() ?? string.Empty,
                Level = ulc.Syllabus.SyllabusContexts
                    .Select(sc => sc.EducationContext.Level.Name)
                    .FirstOrDefault() ?? string.Empty,
                Speciality = ulc.Syllabus.SyllabusContexts
                    .Select(sc => sc.EducationContext.Specialization!.Name)
                    .FirstOrDefault() ?? string.Empty,
                LastUnitName = ulc.UserSyllabusProgress!.UserSyllabusUnitProgresses
                    .OrderByDescending(usup => usup.LastAttemptAt)
                    .Select(usup => usup.SyllabusUnit.Name)
                    .FirstOrDefault() ?? string.Empty,
                LastAccess = ulc.UserSyllabusProgress!.LastAccess,
                Id = ulc.Id,
                SyllabusId2 = ulc.SyllabusId,
                UserSyllabusProgressId = ulc.UserSyllabusProgress!.Id,
            })
            .ToListAsync();

        var syllabusIds = contexts.Select(c => c.SyllabusId).Distinct().ToHashSet();
        var progressIds = contexts.Select(c => c.UserSyllabusProgressId).ToHashSet();

        var subtopicCountsBySyllabus = await _context.SubTopics
            .AsNoTracking()
            .Where(st => st.IsActive && !st.IsDeleted && syllabusIds.Contains(st.Topic.SyllabusUnit.SyllabusId))
            .GroupBy(st => st.Topic.SyllabusUnit.SyllabusId)
            .Select(g => new { SyllabusId = g.Key, Count = g.Count() })
            .ToListAsync();

        var totalBySyllabus = subtopicCountsBySyllabus.ToDictionary(x => x.SyllabusId, x => x.Count);

        var viewedByProgress = await _context.UserSubTopicViews
            .AsNoTracking()
            .Where(ustv =>
                ustv.ViewedAt != default
                && progressIds.Contains(ustv.UserSyllabusUnitProgress.UserSyllabusProgressId))
            .GroupBy(ustv => ustv.UserSyllabusUnitProgress.UserSyllabusProgressId)
            .Select(g => new { UserSyllabusProgressId = g.Key, Count = g.Count() })
            .ToListAsync();

        var progressToSyllabus = contexts.ToDictionary(c => c.UserSyllabusProgressId, c => c.SyllabusId2);
        var viewedBySyllabusDict = viewedByProgress
            .GroupBy(v => progressToSyllabus.GetValueOrDefault(v.UserSyllabusProgressId, 0))
            .ToDictionary(g => g.Key, g => g.Sum(v => v.Count));

        return contexts.Select(c =>
        {
            var sumTotal = totalBySyllabus.GetValueOrDefault(c.SyllabusId, 0);
            var sumViewed = viewedBySyllabusDict.GetValueOrDefault(c.SyllabusId, 0);

            return new DashboardSyllabusDto
            {
                Id = c.SyllabusId,
                Code = c.SyllabusCode,
                Name = c.SyllabusName,
                UserLearningContextId = c.Id,
                LastUnitName = c.LastUnitName,
                CompletedPercentage = sumTotal > 0
                    ? Math.Round((decimal)sumViewed / sumTotal * 100, 2)
                    : 0m,
                LastActivity = DateOnly.FromDateTime(c.LastAccess),
                Slug = c.Slug
            };
        }).ToList();
    }

    public async Task<List<UnitProgressDto>> GetUnitProgressAsync(int userLearningContextId)
    {
        var ids = await _context.UserLearningContexts
            .AsNoTracking()
            .Where(ulc => ulc.Id == userLearningContextId && ulc.UserSyllabusProgress != null)
            .Select(ulc => new { SyllabusId = ulc.SyllabusId, ProgressId = ulc.UserSyllabusProgress!.Id })
            .FirstOrDefaultAsync();

        if (ids is null) return new List<UnitProgressDto>();

        var unitData = await _context.SyllabusUnits
            .AsNoTracking()
            .Where(su => su.SyllabusId == ids.SyllabusId && su.IsActive && !su.IsDeleted)
            .OrderBy(su => su.OrderIndex)
            .Select(su => new
            {
                su.Id,
                su.Name,
                TotalSubTopics = su.Topics
                    .SelectMany(t => t.SubTopics)
                    .Count(st => st.IsActive && !st.IsDeleted),
                UnitProgressId = su.UserSyllabusUnitProgresses
                    .Where(usup => usup.UserSyllabusProgressId == ids.ProgressId)
                    .Select(usup => (int?)usup.Id)
                    .FirstOrDefault()
            })
            .ToListAsync();

        var unitProgressIds = unitData
            .Where(u => u.UnitProgressId.HasValue)
            .Select(u => u.UnitProgressId!.Value)
            .ToHashSet();

        var viewedByUnit = new Dictionary<int, int>();
        if (unitProgressIds.Any())
        {
            viewedByUnit = await _context.UserSubTopicViews
                .AsNoTracking()
                .Where(ustv =>
                    unitProgressIds.Contains(ustv.UserSyllabusUnitProgressId)
                    && ustv.ViewedAt != default)
                .GroupBy(ustv => ustv.UserSyllabusUnitProgressId)
                .Select(g => new { UserSyllabusUnitProgressId = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.UserSyllabusUnitProgressId, x => x.Count);
        }

        return unitData.Select(u => new UnitProgressDto
        {
            UnitId = u.Id,
            UnitName = u.Name,
            CompletedPercentage = u.TotalSubTopics > 0
                ? Math.Round((decimal)viewedByUnit.GetValueOrDefault(u.UnitProgressId ?? 0, 0) / u.TotalSubTopics * 100, 2)
                : 0m
        }).ToList();
    }

    public async Task<decimal> GetOverallProgressPercentageAsync(int userId)
    {
        var syllabusAndProgress = await _context.UserLearningContexts
            .AsNoTracking()
            .Where(ulc => ulc.UserId == userId && ulc.IsActive && !ulc.IsDeleted && ulc.UserSyllabusProgress != null)
            .Select(ulc => new { ulc.SyllabusId, ProgressId = (int?)ulc.UserSyllabusProgress!.Id })
            .ToListAsync();

        if (!syllabusAndProgress.Any()) return 0m;

        var syllabusIds = syllabusAndProgress.Select(x => x.SyllabusId).ToHashSet();
        var progressIds = syllabusAndProgress.Select(x => x.ProgressId).ToHashSet();

        var totalSubTopics = await _context.SubTopics
            .AsNoTracking()
            .CountAsync(st => st.IsActive && !st.IsDeleted
                && syllabusIds.Contains(st.Topic.SyllabusUnit.SyllabusId));

        var viewedSubTopics = await _context.UserSubTopicViews
            .AsNoTracking()
            .CountAsync(ustv =>
                progressIds.Contains(ustv.UserSyllabusUnitProgress.UserSyllabusProgressId)
                && ustv.ViewedAt != default);

        return totalSubTopics > 0
            ? Math.Round((decimal)viewedSubTopics / totalSubTopics * 100, 2)
            : 0m;
    }

    public async Task<int> GetTestCountAsync(int userId)
    {
        return await _context.UserLearningContexts
            .Where(ulc => ulc.UserId == userId && ulc.IsActive && !ulc.IsDeleted)
            .SelectMany(ulc => ulc.AssessmentAttempts)
            .CountAsync(aa =>
                aa.Assessment.Scope == AssessmentScope.UNIT ||
                aa.Assessment.Scope == AssessmentScope.SYLLABUS);
    }

    public async Task<int> GetSimulationCountAsync(int userId)
    {
        return await _context.UserLearningContexts
            .Where(ulc => ulc.UserId == userId && ulc.IsActive && !ulc.IsDeleted)
            .SelectMany(ulc => ulc.AssessmentAttempts)
            .CountAsync(aa => aa.Assessment.Scope == AssessmentScope.SIMULATION);
    }
}
