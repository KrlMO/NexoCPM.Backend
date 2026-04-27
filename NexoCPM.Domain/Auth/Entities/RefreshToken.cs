using NexoCPM.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Auth.Entities
{
    public class RefreshToken
    {
        public int Id { get; private set; }
        public int UserId { get; set; }
        public string DeviceInfo { get; private set; } = string.Empty;
        public string IpAddress { get; private set; } = string.Empty;
        public string Token { get; private set; } = string.Empty;
        public DateTime ExpiresAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Revoked { get; private set; } = false;
        public DateTime? RevokedAt { get; private set; } = null;

        public User User { get; private set; } = null!;

        public RefreshToken() { }

        public RefreshToken(int userId, string token, DateTime expiresAt, string deviceInfo, string ipAddress)
        {
            UserId = userId;
            Token = token;
            ExpiresAt = expiresAt;
            DeviceInfo = deviceInfo;
            IpAddress = ipAddress;

            CreatedAt = DateTime.UtcNow;
            Revoked = false;
        }

        public void Revoke()
        {
            Revoked = true;
            RevokedAt = DateTime.UtcNow;
        }
    }
}
