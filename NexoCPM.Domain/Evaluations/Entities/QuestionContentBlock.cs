using NexoCPM.Domain.Evaluations.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Evaluations.Entities
{
    public class QuestionContentBlock
    {
        public int Id { get; private set; }
        public string? Title { get; private set; } = null;
        public string Content { get; private set; } = string.Empty;
        public string Code { get; private set; } = string.Empty;
        public ContentBlockType Type { get; private set; }
        public ContentBlockRole Role { get; private set; }
        public string? SourceText { get; private set; }
        public string? SourceUrl { get; private set; }

        public ICollection<QuestionContext> QuestionContexts { get; private set; } = new HashSet<QuestionContext>();

        public QuestionContentBlock() { }
    }
}
