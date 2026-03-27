using NexoCPM.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Auth
{
    public class EmailVerificationToken
    {
        public long Id { get; set; }
        public long UsertId { get; set; }
        public string TokenHash { get; set; } = string.Empty;
        public DateTime EmpiresAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        public required User User { get; set; }

        public EmailVerificationToken() { }
    }
}
