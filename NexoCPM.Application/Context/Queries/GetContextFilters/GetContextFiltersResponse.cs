using NexoCPM.Application.Context.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Context.Queries.GetContextFilters
{
    public class GetContextFiltersResponse
    {
        public List<ModalityDto> Modalities { get; set; } = new List<ModalityDto>();
        public List<LevelDto> Levels { get; set; } = new List<LevelDto>();
        public List<SpecializationDto> Specializations { get; set; } = new List<SpecializationDto>();
    }
}
