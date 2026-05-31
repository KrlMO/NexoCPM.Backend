using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Dtos
{
    public class StatGridData
    {
        public int TotalStars { get; set; }
        public int Ranking { get; set; }
        public int TotalSimulations { get; set; }
        public int TotalTests { get; set; }
        public decimal ProgressPercentage { get; set; }
    }
}
