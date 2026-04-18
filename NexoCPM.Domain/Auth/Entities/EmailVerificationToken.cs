using NexoCPM.Domain.Common.Exceptions;
using NexoCPM.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Auth.Entities
{
    public class EmailVerificationToken
    {
        public long Id { get; private set; }
        public long UserId { get; private set; }
        public string TokenHash { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }
        public DateTime ExpiresAt { get; private set; }
        public bool Used { get; private set; }
        public DateTime? UsedAt { get; private set; }
        public User User { get; private set; } = null!;

        private EmailVerificationToken() { }

        public EmailVerificationToken(long userId, string tokenHash, DateTime expiresAt)
        {
            UserId = userId;
            TokenHash = tokenHash;
            ExpiresAt = expiresAt;
            CreatedAt = DateTime.UtcNow;
            Used = false;
        }

        public bool IsExpired()
            => DateTime.UtcNow >= ExpiresAt;

        public bool IsValid()
            => !Used && !IsExpired();

        public void MarkAsUsed()
        {
            if (Used)
                throw new DomainException("Token ya usado");

            if (IsExpired())
                throw new DomainException("Token expirado");

            Used = true;
            UsedAt = DateTime.UtcNow;
        }
    }
}
