using NexoCPM.Application.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Queries.GetTopicSubtopics
{
    public class GetTopicSubtopicsResponse
    {
        public List<UserSyllabusSubtopicData> subTopics { get; set; } = new();
    }
}
