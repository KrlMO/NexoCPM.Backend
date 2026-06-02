using NexoCPM.Application.Context.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Curriculum.Dtos
{
    public class SubTopicDetailDto
    {
        public SubTopicDto SubTopic { get; set; } = new SubTopicDto();
        public List<MicroTopicDto>? MicroTopics { get; set; } = new List<MicroTopicDto>();
        public CompetenceDto? Competence { get; set; }
        public bool Viewed { get; set; }
        public bool IsCompleted { get; set; }
        public int TopicId { get; set; }
    }
}
