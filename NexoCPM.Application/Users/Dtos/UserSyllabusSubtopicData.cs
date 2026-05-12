using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Dtos
{
    public class UserSyllabusSubtopicData
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public bool Viewed { get; set; }
    }
}
