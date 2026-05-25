using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Context.Dtos
{
    public class AbilityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
    }
}
