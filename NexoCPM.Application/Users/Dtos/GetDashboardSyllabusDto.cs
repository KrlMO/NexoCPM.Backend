using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Dtos
{
    public class GetDashboardSyllabusDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Modality { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public string Speciality { get; set; } = string.Empty;
        public string LastUnitName { get; set; } = string.Empty;
        public decimal CompletedPercentage { get; set; }
        public DateOnly LastActivity { get; set; }
    }
}
