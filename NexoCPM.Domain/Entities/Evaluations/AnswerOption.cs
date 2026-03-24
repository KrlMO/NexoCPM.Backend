using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Evaluations
{
    public class AnswerOption
    {
        public long Id { get; set; }
        public long QuestionId { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool IsCorrect { get; set; }

        public required Question Question { get; set; }

        public AnswerOption() { }
    }
}
