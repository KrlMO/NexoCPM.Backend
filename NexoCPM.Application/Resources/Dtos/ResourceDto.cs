using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Resources.Dtos
{
    public class ResourceDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int LikesCount { get; set; }
    }
}
