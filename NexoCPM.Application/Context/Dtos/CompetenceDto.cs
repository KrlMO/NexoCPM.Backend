using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Context.Dtos
{
    public class CompetenceDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public List<CompetenceLevelDto> CompetenceLevels { get; set; } = new List<CompetenceLevelDto>();
        public List<AbilityDto> Abilities { get; set; } = new List<AbilityDto>();
    }
}
