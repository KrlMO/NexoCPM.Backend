using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Evaluations.Entities
{
    public class QuestionContext
    {
        public int QuestionId { get; set; }
        public int QuestionContentBlockId { get; set; }
        public int OrderIndex { get; set; }

        public Question Question { get; set; } = null!;
        public QuestionContentBlock QuestionContentBlock { get; set; } = null!;

        public QuestionContext() { }
    }
}
