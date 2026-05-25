using NexoCPM.Domain.Auth.Entities;
using NexoCPM.Domain.Common;
using NexoCPM.Domain.Evaluations.Entities;
using NexoCPM.Domain.Resources.Entities;
using NexoCPM.Domain.Users.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Users.Entities
{
    public class User : AuditableEntity
    {
        public int Id { get; private set; }
        public string? AvatarUrl { get; private set; } = null;
        public string? Bio { get; private set; } = null;
        public DateTime? DateOfBirth { get; private set; } = null;
        public string? Location { get; private set; } = null;
        public string? PhoneNumber { get; private set; } = null;
        public string? LinkedInProfile { get; private set; } = null;
        public string Code { get; private set; } = string.Empty;
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string UserName { get; private set; } = string.Empty;
        public string Email { get; private set; }  = string.Empty;
        public string PasswordHash { get; private set; } = string.Empty;
        public UserRole UserRole { get; private set; }
        public bool IsActive { get; private set; } = true;
        public bool IsVerified { get; private set; } = false;
        public bool IsDeleted { get; private set; } = false;

        public ICollection<UserResourceView> UserResourceViews { get; set; } = new HashSet<UserResourceView>();
        public ICollection<AssessmentAttempt> AssessmentAttempts { get; set; } = new HashSet<AssessmentAttempt>();
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
        public ICollection<EmailVerificationToken>? EmailVerificationTokens { get; set; } = new HashSet<EmailVerificationToken>();
        public ICollection<UserLearningContext> UserLearningContexts { get; set; } = new HashSet<UserLearningContext>();
        public ICollection<ResourceLike> ResourceLikes { get; set; } = new HashSet<ResourceLike>();
        
        public UserLeaderboard UserLeaderboard { get; set; } = null!;

        public User() { }

        public User(string email, string passwordHash)
        {
            Email = email;
            PasswordHash = passwordHash;
        }

        public User(string firstName, string lastName, string userName, string email, string passwordHash, string code)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
            Code = code;
        }

        public string GetPasswordHash() => PasswordHash;

        public void MarkEmailAsVerified()
        {
            IsVerified = true;
        }
    }
}
