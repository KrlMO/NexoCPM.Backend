using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using NexoCPM.Domain.Context.Entities;
using NexoCPM.Domain.Curriculum.Entities;
using NexoCPM.Persistence.Context;

namespace NexoCPM.Persistence.Seeders;

public static class JsonCurriculumSeeder
{
    private const string DataDir = "Seeders/Json";

    public static async Task SeedAsync(ApplicationDbContext context)
    {
        var basePath = Path.Combine(AppContext.BaseDirectory, DataDir);

        if (!Directory.Exists(basePath))
        {
            Console.WriteLine($"[JsonSeeder] Directory not found: {basePath}");
            return;
        }

        var files = Directory.GetFiles(basePath, "curriculum*.json");
        if (files.Length == 0)
        {
            Console.WriteLine("[JsonSeeder] No JSON files found.");
            return;
        }

        foreach (var file in files)
        {
            Console.WriteLine($"[JsonSeeder] Processing: {Path.GetFileName(file)}");
            var json = await File.ReadAllTextAsync(file);
            var entries = JsonSerializer.Deserialize<List<SyllabusEntry>>(json, JsonOptions);

            if (entries is null) continue;

            foreach (var entry in entries)
            {
                await ImportSyllabusData(context, entry);
            }
        }

        await context.SaveChangesAsync();
        Console.WriteLine("[JsonSeeder] Import completed successfully.");
    }

    private static async Task ImportSyllabusData(ApplicationDbContext context, SyllabusEntry entry)
    {
        var syllabus = await context.Syllabi
            .FirstOrDefaultAsync(s => s.Code == entry.SyllabusCode && s.IsActive && !s.IsDeleted);

        if (syllabus is null)
        {
            Console.WriteLine($"[JsonSeeder] Syllabus not found (code={entry.SyllabusCode}). Skipping.");
            return;
        }

        foreach (var unit in entry.Units)
        {
            var existingUnit = await context.SyllabusUnits
                .FirstOrDefaultAsync(su => su.Code == unit.Code);

            if (existingUnit is not null)
            {
                Console.WriteLine($"[JsonSeeder] Unit already exists (code={unit.Code}). Skipping.");
                continue;
            }

            var syllabusUnit = new SyllabusUnit(
                unit.Code,
                unit.Slug ?? GenerateSlug(unit.Code),
                unit.Name,
                unit.Description ?? string.Empty,
                unit.OrderIndex,
                syllabus.Id
            );
            syllabusUnit.SetCreated(1);

            context.SyllabusUnits.Add(syllabusUnit);
            await context.SaveChangesAsync();

            if (unit.Topics is null) continue;

            foreach (var topic in unit.Topics)
            {
                var existingTopic = await context.SyllabusTopics
                    .FirstOrDefaultAsync(t => t.Code == topic.Code);

                if (existingTopic is not null)
                {
                    Console.WriteLine($"[JsonSeeder] Topic already exists (code={topic.Code}). Skipping.");
                    continue;
                }

                var topicEntity = new Topic(
                    topic.Code,
                    topic.Slug ?? GenerateSlug(topic.Code),
                    topic.Description,
                    topic.OrderIndex,
                    syllabusUnit.Id
                );
                topicEntity.SetCreated(1);

                context.SyllabusTopics.Add(topicEntity);
                await context.SaveChangesAsync();

                if (topic.SubTopics is null) continue;

                foreach (var subTopic in topic.SubTopics)
                {
                    var existingSubTopic = await context.SubTopics
                        .FirstOrDefaultAsync(st => st.Code == subTopic.Code);

                    if (existingSubTopic is not null)
                    {
                        Console.WriteLine($"[JsonSeeder] SubTopic already exists (code={subTopic.Code}). Skipping.");
                        continue;
                    }

                    Competence? competence = null;
                    if (!string.IsNullOrEmpty(subTopic.CompetenceCode))
                    {
                        competence = await context.Competences
                            .FirstOrDefaultAsync(c => c.Code == subTopic.CompetenceCode);

                        if (competence is null)
                        {
                            Console.WriteLine($"[JsonSeeder] Competence not found (code={subTopic.CompetenceCode}). Skipping subtopic {subTopic.Description}.");
                            continue;
                        }
                    }

                    var subTopicEntity = new SubTopic(
                        subTopic.Code,
                        subTopic.Slug ?? GenerateSlug(subTopic.Code),
                        subTopic.Description ?? string.Empty,
                        subTopic.OrderIndex,
                        topicEntity.Id,
                        competence?.Id
                    );
                    subTopicEntity.SetCreated(1);

                    context.SubTopics.Add(subTopicEntity);
                    await context.SaveChangesAsync();

                    if (subTopic.MicroTopics is null) continue;

                    foreach (var microTopic in subTopic.MicroTopics)
                    {
                        var existingMicroTopic = await context.MicroTopics
                            .FirstOrDefaultAsync(mt => mt.Code == microTopic.Code);

                        if (existingMicroTopic is not null)
                        {
                            Console.WriteLine($"[JsonSeeder] MicroTopic already exists (code={microTopic.Code}). Skipping.");
                            continue;
                        }

                        var microTopicEntity = new MicroTopic(
                            microTopic.Code,
                            microTopic.Slug ?? GenerateSlug(microTopic.Code),
                            microTopic.Description,
                            microTopic.OrderIndex,
                            subTopicEntity.Id
                        );
                        microTopicEntity.SetCreated(1);

                        context.MicroTopics.Add(microTopicEntity);
                    }
                }
            }
        }
    }

    private static string GenerateSlug(string code)
    {
        return code.ToLowerInvariant()
            .Replace('_', '-')
            .Replace(' ', '-');
    }

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    private class SyllabusEntry
    {
        public string SyllabusCode { get; set; } = string.Empty;
        public List<UnitEntry> Units { get; set; } = new();
    }

    private class UnitEntry
    {
        public string Code { get; set; } = string.Empty;
        public string? Slug { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int OrderIndex { get; set; }
        public List<TopicEntry>? Topics { get; set; }
    }

    private class TopicEntry
    {
        public string Code { get; set; } = string.Empty;
        public string? Slug { get; set; }
        public string Description { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
        public List<SubTopicEntry>? SubTopics { get; set; }
    }

    private class SubTopicEntry
    {
        public string Code { get; set; } = string.Empty;
        public string? Slug { get; set; }
        public string? Description { get; set; }
        public int OrderIndex { get; set; }
        public string? CompetenceCode { get; set; }
        public List<MicroTopicEntry>? MicroTopics { get; set; }
    }

    private class MicroTopicEntry
    {
        public string Code { get; set; } = string.Empty;
        public string? Slug { get; set; }
        public string Description { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
    }
}
