using NexoCPM.Application.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Queries.GetUnitTopics
{
    public class GetUnitTopicsResponse
    {
        public List<UserSyllabusTopicData> topics { get; set; } = new();
    }
}
