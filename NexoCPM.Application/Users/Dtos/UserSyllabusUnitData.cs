using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Dtos
{
    public class UserSyllabusUnitData
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string? Slug { get; set; } = null;
        public List<UserSyllabusTopicData>? topics { get; set; }
    }
}
