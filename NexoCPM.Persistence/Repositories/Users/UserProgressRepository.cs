using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Commons.Dtos;
using NexoCPM.Application.Users.Dtos;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Evaluations.Enums;
using NexoCPM.Persistence.Context;
using System.Net.Sockets;

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
            .Where(ulc => ulc.UserId == userId && ulc.IsActive && !ulc.IsDeleted)
            .OrderByDescending(ulc => ulc.UserSyllabusProgress.LastAccess)
            .Select(ulc => new
            {
                UserLearningContextId = ulc.Id,
                UserSyllabusProgressId = ulc.UserSyllabusProgress.Id,
                SyllabusName = ulc.Syllabus.Name,
                SyllabusSlug = ulc.Syllabus.Slug,
                UnitData = ulc.UserSyllabusProgress.UserSyllabusUnitProgresses
                    .Select(usup => new
                    {
                        TotalSubTopics = usup.SyllabusUnit.Topics
                            .SelectMany(t => t.SubTopics)
                            .Count(),
                        ViewedSubTopics = usup.UserSubTopicViews
                            .Count(ustv => ustv.IsViewed)
                    })
                    .ToList()
            })
            .ToListAsync();

        return contexts.Select(c =>
        {
            var sumTotal = c.UnitData.Sum(u => u.TotalSubTopics);
            var sumViewed = c.UnitData.Sum(u => u.ViewedSubTopics);

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
            .Where(ulc => ulc.UserId == userId && ulc.IsActive && !ulc.IsDeleted)
            .OrderByDescending(ulc => ulc.UserSyllabusProgress.LastAccess)
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
                LastUnitName = ulc.UserSyllabusProgress.UserSyllabusUnitProgresses
                    .OrderByDescending(usup => usup.LastAttemptAt)
                    .Select(usup => usup.SyllabusUnit.Name)
                    .FirstOrDefault() ?? string.Empty,
                LastAccess = ulc.UserSyllabusProgress.LastAccess,
                Id = ulc.Id,
                UnitData = ulc.UserSyllabusProgress.UserSyllabusUnitProgresses
                    .Select(usup => new
                    {
                        TotalSubTopics = usup.SyllabusUnit.Topics
                            .SelectMany(t => t.SubTopics)
                            .Count(),
                        ViewedSubTopics = usup.UserSubTopicViews
                            .Count(ustv => ustv.IsViewed)
                    })
                    .ToList()
            })
            .ToListAsync();

        return contexts.Select(c =>
        {
            var sumTotal = c.UnitData.Sum(u => u.TotalSubTopics);
            var sumViewed = c.UnitData.Sum(u => u.ViewedSubTopics);

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
            .Where(ulc => ulc.Id == userLearningContextId)
            .Select(ulc => new { ulc.SyllabusId, ProgressId = ulc.UserSyllabusProgress.Id })
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
                ViewedSubTopics = su.UserSyllabusUnitProgresses
                    .Where(usup => usup.UserSyllabusProgressId == ids.ProgressId)
                    .SelectMany(usup => usup.UserSubTopicViews)
                    .Count(ustv => ustv.IsViewed)
            })
            .ToListAsync();

        return unitData.Select(u => new UnitProgressDto
        {
            UnitId = u.Id,
            UnitName = u.Name,
            CompletedPercentage = u.TotalSubTopics > 0
                ? Math.Round((decimal)u.ViewedSubTopics / u.TotalSubTopics * 100, 2)
                : 0m
        }).ToList();
    }

    public async Task<decimal> GetOverallProgressPercentageAsync(int userId)
    {
        var unitData = await _context.UserLearningContexts
            .Where(ulc => ulc.UserId == userId && ulc.IsActive && !ulc.IsDeleted)
            .SelectMany(ulc => ulc.UserSyllabusProgress.UserSyllabusUnitProgresses)
            .Select(usup => new
            {
                TotalSubTopics = usup.SyllabusUnit.Topics
                    .SelectMany(t => t.SubTopics)
                    .Count(),
                ViewedSubTopics = usup.UserSubTopicViews
                    .Count(ustv => ustv.IsViewed)
            })
            .ToListAsync();

        var sumTotal = unitData.Sum(u => u.TotalSubTopics);
        var sumViewed = unitData.Sum(u => u.ViewedSubTopics);

        return sumTotal > 0
            ? Math.Round((decimal)sumViewed / sumTotal * 100, 2)
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
