using NexoCPM.Domain.Common.Exceptions;
using NexoCPM.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Auth.Entities
{
    public class EmailVerificationToken
    {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public string TokenHash { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }
        public DateTime ExpiresAt { get; private set; }
        public bool IsUsed { get; private set; }
        public DateTime? UsedAt { get; private set; } = null;
        public User User { get; private set; } = null!;

        private EmailVerificationToken() { }

        public EmailVerificationToken(int userId, string tokenHash, DateTime expiresAt)
        {
            UserId = userId;
            TokenHash = tokenHash;
            ExpiresAt = expiresAt;
            CreatedAt = DateTime.UtcNow;
            IsUsed = false;
        }

        public bool IsExpired()
            => DateTime.UtcNow >= ExpiresAt;

        public bool IsValid()
            => !IsUsed && !IsExpired();

        public void MarkAsUsed()
        {
            if (IsUsed)
                throw new TokenAlreadyUsedException();

            if (IsExpired())
                throw new TokenExpiredException();

            IsUsed = true;
            UsedAt = DateTime.UtcNow;
        }

        public void Invalidate()
        {
            IsUsed = true;
            UsedAt = DateTime.UtcNow;
        }
    }
}
