using NexoCPM.Domain.Users.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Auth.Dtos
{
    public class AuthUserDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? AvatarUrl { get; set; }
        public UserRole UserRole { get; set; }
        public int NumberStar { get; set; }
    }
}
