using NexoCPM.Domain.Evaluations.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Evaluations.Entities
{
    public class QuestionContentBlock
    {
        public int Id { get; private set; }
        public string Content { get; private set; } = string.Empty;
        public string Code { get; private set; } = string.Empty;
        public int OrderIndex { get; private set; }
        public int QuestionId { get; private set; }
        public ContentBlockType Type { get; private set; }

        public Question Question { get; private set; } = null!;

        public QuestionContentBlock() { }
    }
}
