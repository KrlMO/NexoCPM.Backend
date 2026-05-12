using NexoCPM.Domain.Users.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Dtos
{
    public class UserSyllabusDetailData
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public DateOnly? LastAccess { get; set; }
        public decimal CompletedPercentage { get; set; }
        public string Status { get; set; } = string.Empty;
        public List<UserSyllabusUnitData>? units { get; set; }
    }
}
