using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using NexoCPM.Domain.Context.Entities;
using NexoCPM.Persistence.Context;

namespace NexoCPM.Persistence.Seeders;

public static class JsonCompetenceSeeder
{
    private const string Pattern = "*competence*";

    public static async Task SeedAsync(ApplicationDbContext context)
    {
        var basePath = Path.Combine(AppContext.BaseDirectory, "Seeders", "Json");

        if (!Directory.Exists(basePath))
        {
            Console.WriteLine("[CompetenceSeeder] Directory not found.");
            return;
        }

        var files = Directory.GetFiles(basePath, "*.json")
            .Where(f => Path.GetFileNameWithoutExtension(f).Contains("competence"))
            .ToList();

        if (files.Count == 0)
        {
            Console.WriteLine("[CompetenceSeeder] No competence JSON files found.");
            return;
        }

        foreach (var file in files)
        {
            Console.WriteLine($"[CompetenceSeeder] Processing: {Path.GetFileName(file)}");
            var json = await File.ReadAllTextAsync(file);
            var entries = JsonSerializer.Deserialize<List<CompetenceEntry>>(json, JsonOptions);
            if (entries is null) continue;

            foreach (var entry in entries)
            {
                await ImportCompetence(context, entry);
            }
        }

        await context.SaveChangesAsync();
        Console.WriteLine("[CompetenceSeeder] Import completed.");
    }

    private static async Task ImportCompetence(ApplicationDbContext context, CompetenceEntry entry)
    {
        var existing = await context.Competences
            .FirstOrDefaultAsync(c => c.Code == entry.Code);

        if (existing is not null)
        {
            existing.Update(entry.Name, entry.Description, entry.EffectYear);
            Console.WriteLine($"[CompetenceSeeder] Competence updated (code={entry.Code}).");
        }
        else
        {
            existing = new Competence(entry.Code, entry.Name, entry.Description, entry.EffectYear);
            existing.SetCreated(1);
            context.Competences.Add(existing);
            await context.SaveChangesAsync();
        }

        if (entry.Abilities is not null)
        {
            foreach (var ab in entry.Abilities)
            {
                var existingAbility = await context.Abilities
                    .FirstOrDefaultAsync(a => a.Code == ab.Code);

                if (existingAbility is not null)
                {
                    existingAbility.Update(ab.Name, ab.Description);
                    Console.WriteLine($"[CompetenceSeeder] Ability updated (code={ab.Code}).");
                    continue;
                }

                var ability = new Ability(ab.Code, ab.Name, ab.Description, existing.Id);
                ability.SetCreated(1);
                context.Abilities.Add(ability);
            }
        }

        if (entry.Levels is not null)
        {
            foreach (var lvl in entry.Levels)
            {
                var existingLevel = await context.CompetenceLevels
                    .FirstOrDefaultAsync(cl => cl.Code == lvl.Code);

                if (existingLevel is not null)
                {
                    existingLevel.Update(lvl.LevelNumber, lvl.Description);
                    Console.WriteLine($"[CompetenceSeeder] CompetenceLevel updated (code={lvl.Code}).");
                    continue;
                }

                var level = new CompetenceLevel(lvl.Code, lvl.LevelNumber, lvl.Description, existing.Id);
                level.SetCreated(1);
                context.CompetenceLevels.Add(level);
            }
        }
    }

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    private class CompetenceEntry
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int EffectYear { get; set; }
        public List<AbilityEntry>? Abilities { get; set; }
        public List<LevelEntry>? Levels { get; set; }
    }

    private class AbilityEntry
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    private class LevelEntry
    {
        public string Code { get; set; } = string.Empty;
        public int LevelNumber { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
