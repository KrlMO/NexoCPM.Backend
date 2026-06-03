using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Commons.Dtos;
using NexoCPM.Application.Evaluations.Dtos;
using NexoCPM.Application.Evaluations.Ports;
using NexoCPM.Application.Users.Dtos;
using NexoCPM.Domain.Evaluations.Enums;
using NexoCPM.Persistence.Context;

namespace NexoCPM.Persistence.Repositories.Evaluations;

public class AssessmentAttemptRepository : IAssessmentAttemptRepository
{
    private readonly ApplicationDbContext _context;

    public AssessmentAttemptRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<SimulationDto>> GetLastSimulationsAsync(int userId, int count)
    {
        return await _context.UserLearningContexts
            .Where(ulc => ulc.UserId == userId && ulc.IsActive && !ulc.IsDeleted)
            .SelectMany(ulc => ulc.AssessmentAttempts)
            .Where(aa => aa.Assessment.Scope == AssessmentScope.SIMULATION)
            .OrderByDescending(aa => aa.FinishedAt)
            .Take(count)
            .Select(aa => new SimulationDto
            {
                ModalityName = aa.UserLearningContext.Syllabus.SyllabusContexts
                    .Select(sc => sc.EducationContext.Level.Modality.Name)
                    .FirstOrDefault() ?? string.Empty,
                Levelname = aa.UserLearningContext.Syllabus.SyllabusContexts
                    .Select(sc => sc.EducationContext.Level.Name)
                    .FirstOrDefault() ?? string.Empty,
                SpecialityName = aa.UserLearningContext.Syllabus.SyllabusContexts
                    .Select(sc => sc.EducationContext.Specialization!.Name)
                    .FirstOrDefault() ?? string.Empty,
                FinishedAt = DateOnly.FromDateTime(aa.FinishedAt),
                Score = aa.Score,
                TotalQuestions = aa.TotalQuestions,
                CorrectAnswers = aa.CorrectAnswers,
                DurationMinutes = EF.Functions.DateDiffMinute(aa.StartedAt, aa.FinishedAt),
                StarsEarned = aa.StarsEarned,
                type = "SIMULATION"
            })
            .ToListAsync();
    }

    public async Task<List<AssessmentChartDto>> GetLastTestChartDataAsync(int userId, int count)
    {
        return await _context.UserLearningContexts
            .Where(ulc => ulc.UserId == userId && ulc.IsActive && !ulc.IsDeleted)
            .SelectMany(ulc => ulc.AssessmentAttempts)
            .Where(aa => aa.Assessment.Scope == AssessmentScope.UNIT
                      || aa.Assessment.Scope == AssessmentScope.SYLLABUS)
            .OrderByDescending(aa => aa.FinishedAt)
            .Take(count)
            .Select(aa => new AssessmentChartDto
            {
                AttemptId = aa.Id,
                AssessmentId = aa.AssessmentId,
                Score = aa.Score,
                TotalQuestions = aa.TotalQuestions,
                FinishedAt = aa.FinishedAt
            })
            .ToListAsync();
    }

    public async Task<List<AssessmentChartDto>> GetLastSimulationChartDataAsync(int userId, int count)
    {
        return await _context.UserLearningContexts
            .Where(ulc => ulc.UserId == userId && ulc.IsActive && !ulc.IsDeleted)
            .SelectMany(ulc => ulc.AssessmentAttempts)
            .Where(aa => aa.Assessment.Scope == AssessmentScope.SIMULATION)
            .OrderByDescending(aa => aa.FinishedAt)
            .Take(count)
            .Select(aa => new AssessmentChartDto
            {
                AttemptId = aa.Id,
                AssessmentId = aa.AssessmentId,
                Score = aa.Score,
                TotalQuestions = aa.TotalQuestions,
                FinishedAt = aa.FinishedAt
            })
            .ToListAsync();
    }

    public async Task<List<RecommendationDto>> GetFailedSubtopicsAsync(int userLearningContextId, int count)
    {
        var failedSubtopics = await _context.AssessmentAttempts
            .Where(aa => aa.UserLearningContextId == userLearningContextId)
            .SelectMany(aa => aa.AssessmentAttemptQuestions)
            .Where(aaq => aaq.SelectedOptionId.HasValue && !aaq.SelectedOption!.IsCorrect)
            .GroupBy(aaq => new { aaq.Question.SubTopic.Id, aaq.Question.SubTopic.Description, aaq.Question.SubTopic.Slug })
            .OrderByDescending(g => g.Max(aaq => aaq.AssessmentAttempt.FinishedAt))
            .Take(count)
            .Select(g => new
            {
                Description = g.Key.Description,
                Slug = g.Key.Slug
            })
            .ToListAsync();

        return failedSubtopics.Select(st => new RecommendationDto
        {
            Message = "Refuerza: " + (st.Description.Length > 80 ? st.Description[..80] : st.Description),
            SubtopicSlug = st.Slug
        }).ToList();
    }

    public async Task<PaginatedResult<SimulationHistoryDto>> GetSimulationHistoryAsync(int userId, int page, int pageSize)
    {
        var query = _context.UserLearningContexts
            .Where(ulc => ulc.UserId == userId && ulc.IsActive && !ulc.IsDeleted)
            .SelectMany(ulc => ulc.AssessmentAttempts)
            .Where(aa => aa.Assessment.Scope == AssessmentScope.SIMULATION);

        var totalCount = await query.CountAsync();

        var items = await query
            .OrderByDescending(aa => aa.FinishedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(aa => new SimulationHistoryDto
            {
                AttemptId = aa.Id,
                AssessmentId = aa.AssessmentId,
                AssessmentCode = aa.Assessment.Code,
                Title = "Simulacro de: " + aa.UserLearningContext.Syllabus.Name,
                SyllabusName = aa.UserLearningContext.Syllabus.Name,
                SyllabusSlug = aa.UserLearningContext.Syllabus.Slug,
                Score = aa.Score,
                TotalQuestions = aa.TotalQuestions,
                CorrectAnswers = aa.CorrectAnswers,
                StarsEarned = aa.StarsEarned,
                DurationMinutes = EF.Functions.DateDiffMinute(aa.StartedAt, aa.FinishedAt),
                FinishedAt = aa.FinishedAt
            })
            .ToListAsync();

        return new PaginatedResult<SimulationHistoryDto>
        {
            Items = items,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize
        };
    }

    public async Task<List<string>> GetTopFailedSubtopicsAsync(int userId, int topCount)
    {
        return await _context.UserLearningContexts
            .Where(ulc => ulc.UserId == userId && ulc.IsActive && !ulc.IsDeleted)
            .SelectMany(ulc => ulc.AssessmentAttempts)
            .OrderByDescending(aa => aa.FinishedAt)
            .Take(10)
            .SelectMany(aa => aa.AssessmentAttemptQuestions)
            .Where(aaq => aaq.SelectedOptionId.HasValue && !aaq.SelectedOption!.IsCorrect)
            .GroupBy(aaq => aaq.Question.SubTopic.Description)
            .OrderByDescending(g => g.Count())
            .Take(topCount)
            .Select(g => g.Key)
            .ToListAsync();
    }
}
