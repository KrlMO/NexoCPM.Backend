using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Dtos
{
    public class SimulationDto
    {
        public string ModalityName { get; set; } = string.Empty;
        public string Levelname { get; set; } = string.Empty;
        public string SpecialityName { get; set; } = string.Empty;
        public DateOnly FinishedAt { get; set; }
        public decimal Score { get; set; }
        public int TotalQuestions { get; set; }
        public int CorrectAnswers { get; set; }
        public int DurationMinutes { get; set; }
        public int StarsEarned { get; set; }
        public string type { get; set; } = string.Empty;
    }
}
