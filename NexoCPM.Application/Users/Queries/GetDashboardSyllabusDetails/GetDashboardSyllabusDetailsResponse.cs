using NexoCPM.Application.Users.Dtos;
using System.Collections.Generic;

namespace NexoCPM.Application.Users.Queries.GetDashboardSyllabusDetails
{
    public class GetDashboardSyllabusDetailsResponse
    {
        public List<UnitProgressDto> Units { get; set; } = new List<UnitProgressDto>();
        public List<RecommendationDto> Recommendations { get; set; } = new List<RecommendationDto>();
    }
}
