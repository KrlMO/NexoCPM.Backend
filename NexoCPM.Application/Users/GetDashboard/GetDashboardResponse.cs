using NexoCPM.Application.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.GetDashboard
{
    public class GetDashboardResponse
    {
        public int TotalStars { get; set; }
        public int Ranking { get; set; }
        public int TotalSimulations { get; set; }
        public int TotalTests { get; set; }
        public decimal ProgressPercentage { get; set; }
        public List<GetDashboardSyllabusDto> ActiveSyllabus { get; set; } = new List<GetDashboardSyllabusDto>();
        public GetDashboardSyllabusDto LastSyllabus { get; set; } = null!;
        public List<string> Recomendations { get; set; } = new List<string>();
        public List<GetDashboardSimulationsDto> LastSimulations { get; set; } = new List<GetDashboardSimulationsDto>();
        public int TotalSyllabus { get; set; }
        public bool UserHasInfo { get; set; }
    }
}
