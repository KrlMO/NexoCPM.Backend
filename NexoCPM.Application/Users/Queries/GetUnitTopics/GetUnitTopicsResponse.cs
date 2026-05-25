using NexoCPM.Application.Evaluations.Dtos;
using NexoCPM.Application.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Queries.GetUnitTopics
{
    public class GetUnitTopicsResponse
    {
        public List<UserSyllabusTopicData> Topics { get; set; } = new();
        public AssessmentDto? UnitTest { get; set; }
    }
}
