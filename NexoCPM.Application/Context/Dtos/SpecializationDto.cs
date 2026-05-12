using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Context.Dtos
{
    public class SpecializationDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
    }
}
