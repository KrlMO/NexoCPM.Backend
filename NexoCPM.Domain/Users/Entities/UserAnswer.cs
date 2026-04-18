using NexoCPM.Domain.Evaluations.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Users.Entities
{
    public class UserAnswer
    {
        public long UserId { get; set; }
        public long QuestionId { get; set; }
        public long AnswerOptionId { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime AnsweredAt { get; set; }

        public required User User { get; set; }
        public required Question Question { get; set; }
        public required AnswerOption AnswerOption { get; set; }

        public UserAnswer() { }
    }
}
