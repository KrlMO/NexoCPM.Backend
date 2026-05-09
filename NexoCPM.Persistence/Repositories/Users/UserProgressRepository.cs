using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Users.Dtos;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Persistence.Context;

namespace NexoCPM.Persistence.Repositories.Users;

public class UserProgressRepository : IUserProgressRepository
{
    private readonly ApplicationDbContext _context;

    public UserProgressRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<GetDashboardSyllabusDto>> GetActiveSyllabusProgressAsync(int userId)
    {
        var contexts = await _context.UserLearningContexts
            .Where(ulc => ulc.UserId == userId && ulc.IsActive && !ulc.IsDeleted)
            .Select(ulc => new
            {
                SyllabusId = ulc.Syllabus.Id,
                SyllabusCode = ulc.Syllabus.Code,
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

            return new GetDashboardSyllabusDto
            {
                Id = c.SyllabusId,
                Code = c.SyllabusCode,
                Modality = c.Modality,
                Level = c.Level,
                Speciality = c.Speciality,
                LastUnitName = c.LastUnitName,
                CompletedPercentage = sumTotal > 0
                    ? Math.Round((decimal)sumViewed / sumTotal * 100, 2)
                    : 0m,
                LastActivity = DateOnly.FromDateTime(c.LastAccess)
            };
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
}
