using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using NexoCPM.Domain.Evaluations.Entities;
using NexoCPM.Domain.Evaluations.Enums;
using NexoCPM.Persistence.Context;

namespace NexoCPM.Persistence.Seeders;

public static class JsonAssessmentSeeder
{
    private const string Pattern = "*assessment*";

    public static async Task SeedAsync(ApplicationDbContext context)
    {
        var basePath = Path.Combine(AppContext.BaseDirectory, "Seeders", "Json");

        if (!Directory.Exists(basePath))
        {
            Console.WriteLine("[AssessmentSeeder] Directory not found.");
            return;
        }

        var files = Directory.GetFiles(basePath, "*.json")
            .Where(f => Path.GetFileNameWithoutExtension(f).Contains("assessment"))
            .ToList();

        if (files.Count == 0)
        {
            Console.WriteLine("[AssessmentSeeder] No assessment JSON files found.");
            return;
        }

        foreach (var file in files)
        {
            Console.WriteLine($"[AssessmentSeeder] Processing: {Path.GetFileName(file)}");
            var json = await File.ReadAllTextAsync(file);
            var entries = JsonSerializer.Deserialize<List<AssessmentEntry>>(json, JsonOptions);
            if (entries is null) continue;

            foreach (var entry in entries)
            {
                await ImportAssessment(context, entry);
            }
        }

        await context.SaveChangesAsync();
        Console.WriteLine("[AssessmentSeeder] Import completed.");
    }

    private static async Task ImportAssessment(ApplicationDbContext context, AssessmentEntry entry)
    {
        var existing = await context.Assessments
            .FirstOrDefaultAsync(a => a.Code == entry.Code);

        if (existing is not null)
        {
            Console.WriteLine($"[AssessmentSeeder] Assessment already exists (code={entry.Code}). Skipping.");
            return;
        }

        int? targetId = null;

        if ((AssessmentType)entry.Type != AssessmentType.GENERAL_SKILLS)
        {
            switch ((AssessmentScope)entry.Scope)
            {
                case AssessmentScope.UNIT:
                    if (!string.IsNullOrEmpty(entry.UnitCode))
                    {
                        var unit = await context.SyllabusUnits
                            .FirstOrDefaultAsync(u => u.Code == entry.UnitCode && u.IsActive && !u.IsDeleted);

                        if (unit is null)
                        {
                            Console.WriteLine($"[AssessmentSeeder] Unit not found (code={entry.UnitCode}). Skipping assessment {entry.Code}.");
                            return;
                        }
                        targetId = unit.Id;
                    }
                    break;

                case AssessmentScope.SYLLABUS:
                case AssessmentScope.SIMULATION:
                    if (!string.IsNullOrEmpty(entry.SyllabusCode))
                    {
                        var syllabus = await context.Syllabi
                            .FirstOrDefaultAsync(s => s.Code == entry.SyllabusCode && s.IsActive && !s.IsDeleted);

                        if (syllabus is null)
                        {
                            Console.WriteLine($"[AssessmentSeeder] Syllabus not found (code={entry.SyllabusCode}). Skipping assessment {entry.Code}.");
                            return;
                        }
                        targetId = syllabus.Id;
                    }
                    break;
            }
        }

        var assessment = new Assessment();
        context.Assessments.Add(assessment);

        var e = context.Entry(assessment);
        e.Property("Code").CurrentValue = entry.Code;
        e.Property("Title").CurrentValue = entry.Title;
        e.Property("Type").CurrentValue = (AssessmentType)entry.Type;
        e.Property("Scope").CurrentValue = (AssessmentScope)entry.Scope;
        e.Property("TargetId").CurrentValue = targetId;
        e.Property("IsActive").CurrentValue = entry.IsActive;
        e.Property("NumberQuestions").CurrentValue = entry.NumberQuestions;
        e.Property("TimeLimitSeconds").CurrentValue = entry.TimeLimitSeconds;
        e.Property("MaxAttempts").CurrentValue = entry.MaxAttempts;
        Console.WriteLine($"[AssessmentSeeder] Assessment imported (code={entry.Code}).");
    }

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    private class AssessmentEntry
    {
        public string Code { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int Type { get; set; }
        public int Scope { get; set; }
        public bool IsActive { get; set; } = true;
        public int NumberQuestions { get; set; }
        public string? SyllabusCode { get; set; }
        public string? UnitCode { get; set; }
        public int? TimeLimitSeconds { get; set; }
        public int? MaxAttempts { get; set; }
    }
}
