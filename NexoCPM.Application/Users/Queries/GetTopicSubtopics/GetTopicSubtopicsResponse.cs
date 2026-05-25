using NexoCPM.Application.Evaluations.Dtos;
using NexoCPM.Application.Users.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Queries.GetTopicSubtopics
{
    public class GetTopicSubtopicsResponse
    {
        public List<UserSyllabusSubtopicData> subTopics { get; set; } = new();
        public AssessmentDto UnitAssessment { get; set; } = new AssessmentDto();
    }
}
