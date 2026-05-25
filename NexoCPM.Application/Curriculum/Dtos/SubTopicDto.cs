using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Curriculum.Dtos
{
    public class SubTopicDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
        public int TopicId { get; set; }
    }
}
