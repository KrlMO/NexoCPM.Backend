using Microsoft.EntityFrameworkCore;
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
