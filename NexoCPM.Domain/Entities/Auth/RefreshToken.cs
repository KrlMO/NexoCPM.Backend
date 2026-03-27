using NexoCPM.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Auth
{
    public class RefreshToken
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string DeviceInfo { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Revoked { get; set; }
        public DateTime RevokedAt { get; set; }

        public required User User { get; set; }

        public RefreshToken() { }
    }
}
