using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using NexoCPM.Domain.Evaluations.Entities;
using NexoCPM.Domain.Evaluations.Enums;
using NexoCPM.Persistence.Context;

namespace NexoCPM.Persistence.Seeders;

public static class JsonQuestionSeeder
{
    public static async Task SeedAsync(ApplicationDbContext context)
    {
        var basePath = Path.Combine(AppContext.BaseDirectory, "Seeders", "Json");

        if (!Directory.Exists(basePath))
        {
            Console.WriteLine("[QuestionSeeder] Directory not found.");
            return;
        }

        var files = Directory.GetFiles(basePath, "*.json")
            .Where(f => Path.GetFileNameWithoutExtension(f).StartsWith("questions_"))
            .ToList();

        if (files.Count == 0)
        {
            Console.WriteLine("[QuestionSeeder] No question JSON files found.");
            return;
        }

        foreach (var file in files)
        {
            Console.WriteLine($"[QuestionSeeder] Processing: {Path.GetFileName(file)}");
            var json = await File.ReadAllTextAsync(file);
            var entries = JsonSerializer.Deserialize<List<QuestionFileEntry>>(json, JsonOptions);
            if (entries is null) continue;

            foreach (var entry in entries)
            {
                await ImportEntryAsync(context, entry);
            }
        }

        Console.WriteLine("[QuestionSeeder] Import completed.");
    }

    private static async Task ImportEntryAsync(ApplicationDbContext context, QuestionFileEntry entry)
    {
        var blockDict = new Dictionary<string, QuestionContentBlock>();

        foreach (var blockEntry in entry.Blocks)
        {
            if (string.IsNullOrWhiteSpace(blockEntry.Code) ||
                string.IsNullOrWhiteSpace(blockEntry.Type) ||
                string.IsNullOrWhiteSpace(blockEntry.Role))
            {
                Console.WriteLine($"[QuestionSeeder] Skipping block with empty code/type/role.");
                continue;
            }

            var existing = await context.QuestionContentBlocks
                .FirstOrDefaultAsync(b => b.Code == blockEntry.Code);

            if (existing is not null)
            {
                blockDict[blockEntry.Code] = existing;
                continue;
            }

            var block = new QuestionContentBlock();
            context.QuestionContentBlocks.Add(block);
            var e = context.Entry(block);
            e.Property("Code").CurrentValue = blockEntry.Code;
            e.Property("Content").CurrentValue = blockEntry.Content;
            e.Property("Type").CurrentValue = Enum.Parse<ContentBlockType>(blockEntry.Type);
            e.Property("Role").CurrentValue = Enum.Parse<ContentBlockRole>(blockEntry.Role);
            if (blockEntry.Title is not null)
                e.Property("Title").CurrentValue = blockEntry.Title;
            if (blockEntry.SourceText is not null)
                e.Property("SourceText").CurrentValue = blockEntry.SourceText;
            if (blockEntry.SourceUrl is not null)
                e.Property("SourceUrl").CurrentValue = blockEntry.SourceUrl;

            blockDict[blockEntry.Code] = block;
        }

        await context.SaveChangesAsync();

        foreach (var questionEntry in entry.Questions)
        {
            var existingQuestion = await context.Questions
                .FirstOrDefaultAsync(q => q.Code == questionEntry.Code);

            if (existingQuestion is not null)
            {
                Console.WriteLine($"[QuestionSeeder] Question already exists (code={questionEntry.Code}). Skipping.");
                continue;
            }

            var subTopic = await context.SubTopics
                .FirstOrDefaultAsync(st => st.Code == questionEntry.SubtopicCode && st.IsActive && !st.IsDeleted);

            if (subTopic is null)
            {
                Console.WriteLine($"[QuestionSeeder] SubTopic not found (code={questionEntry.SubtopicCode}). Skipping question {questionEntry.Code}.");
                continue;
            }

            var question = new Question();
            context.Questions.Add(question);
            var eq = context.Entry(question);
            eq.Property("Code").CurrentValue = questionEntry.Code;
            eq.Property("Statement").CurrentValue = questionEntry.Statement;
            eq.Property("SubTopicId").CurrentValue = subTopic.Id;

            await context.SaveChangesAsync();

            foreach (var optionEntry in questionEntry.Options)
            {
                var option = new Option();
                context.Options.Add(option);
                var eo = context.Entry(option);
                eo.Property("QuestionId").CurrentValue = question.Id;
                eo.Property("Label").CurrentValue = optionEntry.Label;
                eo.Property("IsCorrect").CurrentValue = optionEntry.IsCorrect;

                await context.SaveChangesAsync();

                foreach (var blockEntry in optionEntry.Blocks)
                {
                    var optionBlock = new OptionBlock();
                    context.OptionBlocks.Add(optionBlock);
                    var eob = context.Entry(optionBlock);
                    eob.Property("OptionId").CurrentValue = option.Id;
                    eob.Property("Content").CurrentValue = blockEntry.Content;
                    eob.Property("Type").CurrentValue = Enum.Parse<ContentBlockType>(blockEntry.Type);
                    eob.Property("OrderIndex").CurrentValue = blockEntry.OrderIndex;
                }
            }

            foreach (var blockRef in questionEntry.Blocks)
            {
                if (!blockDict.TryGetValue(blockRef.BlockCode, out var block))
                {
                    Console.WriteLine($"[QuestionSeeder] Block not found (code={blockRef.BlockCode}) for question {questionEntry.Code}.");
                    continue;
                }

                context.QuestionContexts.Add(new QuestionContext
                {
                    QuestionId = question.Id,
                    QuestionContentBlockId = block.Id,
                    OrderIndex = blockRef.OrderIndex
                });
            }

            await context.SaveChangesAsync();

            Console.WriteLine($"[QuestionSeeder] Question imported (code={questionEntry.Code}).");
        }
    }

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    private class QuestionFileEntry
    {
        public List<BlockEntry> Blocks { get; set; } = new();
        public List<QuestionEntry> Questions { get; set; } = new();
    }

    private class BlockEntry
    {
        public string Code { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string? Title { get; set; }
        public string? SourceText { get; set; }
        public string? SourceUrl { get; set; }
    }

    private class QuestionEntry
    {
        public string Code { get; set; } = string.Empty;
        public string SubtopicCode { get; set; } = string.Empty;
        public string Statement { get; set; } = string.Empty;
        public List<BlockRefEntry> Blocks { get; set; } = new();
        public List<OptionEntry> Options { get; set; } = new();
    }

    private class BlockRefEntry
    {
        public string BlockCode { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
    }

    private class OptionEntry
    {
        public string Label { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }
        public List<OptionBlockEntry> Blocks { get; set; } = new();
    }

    private class OptionBlockEntry
    {
        public string Content { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
    }
}
