using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Context.Dtos
{
    public class CompetenceLevelDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public int LevelNumber { get; set; }
    }
}
