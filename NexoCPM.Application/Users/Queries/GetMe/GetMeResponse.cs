using System;

namespace NexoCPM.Application.Users.Queries.GetMe
{
    public class GetMeResponse
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string? Bio { get; set; }
        public string? LinkedInProfile { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsPublic { get; set; }
        public string? AvatarUrl { get; set; }
    }
}
