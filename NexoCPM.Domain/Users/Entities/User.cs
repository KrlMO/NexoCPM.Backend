using NexoCPM.Domain.Auth.Entities;
using NexoCPM.Domain.Common;
using NexoCPM.Domain.Evaluations.Entities;
using NexoCPM.Domain.Users.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Users.Entities
{
    public class User : AuditableEntity
    {
        public long Id { get; private set; }
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string UserName { get; private set; } = string.Empty;
        public string Email { get; private set; }  = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public UserRole UserRole { get; private set; }
        public bool IsActive { get; private set; } = true;
        public bool IsVerified { get; private set; } = false;
        public bool IsDeleted { get; private set; } = false;

        public ICollection<UserSyllabusUnitProgress> UserSyllabusUnitProgresses { get; set; } = new List<UserSyllabusUnitProgress>();
        public ICollection<UserSyllabusProgress> UserSyllabusProgresses { get; set; } = new HashSet<UserSyllabusProgress>();
        public ICollection<UserResourceView> UserResourceViews { get; set; } = new HashSet<UserResourceView>();
        public ICollection<AssesmentAttempt> AssesmentAttempts { get; set; } = new HashSet<AssesmentAttempt>();
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
        public ICollection<EmailVerificationToken>? EmailVerificationTokens { get; set; } = new HashSet<EmailVerificationToken>();

        public User() { }

        public User(string email, string passwordHash)
        {
            Email = email;
            PasswordHash = passwordHash;
        }

        public string GetPasswordHash() => PasswordHash;
    }
}
