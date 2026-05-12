using NexoCPM.Application.Commons.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Curriculum.Queries.GetFeaturedSyllabus
{
    public class GetFeaturedSyllabusResponse
    {
        public List<DashboardSyllabusDto>? featuredSyllabus { get; set; }
    }
}
