using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Dtos
{
    public class UserSyllabusDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public DateOnly LastAccess { get; set; } = new DateOnly();
    }
}
