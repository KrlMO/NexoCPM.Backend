using NexoCPM.Application.Users.Dtos;
using System.Collections.Generic;

namespace NexoCPM.Application.Users.Queries.GetMainDashboard
{
    public class GetMainDashboardResponse
    {
        public StatGridData StatGridData { get; set; } = new StatGridData();
        public List<SyllabusProgressDto> SyllabiProgress { get; set; } = new List<SyllabusProgressDto>();
        public List<AssessmentChartDto> LastTests { get; set; } = new List<AssessmentChartDto>();
        public List<AssessmentChartDto> LastSimulations { get; set; } = new List<AssessmentChartDto>();
    }
}
