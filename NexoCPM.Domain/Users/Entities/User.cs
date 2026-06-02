using NexoCPM.Domain.Auth.Entities;
using NexoCPM.Domain.Common;
using NexoCPM.Domain.Evaluations.Entities;
using NexoCPM.Domain.Resources.Entities;
using NexoCPM.Domain.Users.Enums;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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
        public string SecurityStamp { get; private set; } = string.Empty;
        public UserRole UserRole { get; private set; }
        public bool IsActive { get; private set; } = true;
        public bool IsVerified { get; private set; } = false;
        public bool IsDeleted { get; private set; } = false;
        public bool IsPublic { get; private set; } = true;

        public ICollection<UserResourceView> UserResourceViews { get; set; } = new HashSet<UserResourceView>();
        public ICollection<AssessmentAttempt> AssessmentAttempts { get; set; } = new HashSet<AssessmentAttempt>();
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
        public ICollection<EmailVerificationToken>? EmailVerificationTokens { get; set; } = new HashSet<EmailVerificationToken>();
        public ICollection<PasswordResetToken> PasswordResetTokens { get; set; } = new HashSet<PasswordResetToken>();
        public ICollection<UserLearningContext> UserLearningContexts { get; set; } = new HashSet<UserLearningContext>();
        public ICollection<ResourceLike> ResourceLikes { get; set; } = new HashSet<ResourceLike>();
        
        public UserLeaderboard UserLeaderboard { get; set; } = null!;

        public User() { }

        public User(string email, string passwordHash)
        {
            Email = email;
            PasswordHash = passwordHash;
            SecurityStamp = GenerateStamp();
        }

        public User(string firstName, string lastName, string userName, string email, string passwordHash, string code)
        {
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
            Code = code;
            SecurityStamp = GenerateStamp();
        }

        public string GetPasswordHash() => PasswordHash;

        public void MarkEmailAsVerified()
        {
            IsVerified = true;
        }

        public void ChangePassword(string newPasswordHash)
        {
            PasswordHash = newPasswordHash;
            SecurityStamp = GenerateStamp();
        }

        public void UpdateGeneralData(string? firstName, string? lastName, string? userName)
        {
            if (firstName is not null) FirstName = firstName;
            if (lastName is not null) LastName = lastName;
            if (userName is not null) UserName = userName;
        }

        public void UpdatePrivateData(DateOnly? dateOfBirth, string? phoneNumber)
        {
            if (dateOfBirth.HasValue) DateOfBirth = dateOfBirth.Value.ToDateTime(TimeOnly.MinValue);
            if (phoneNumber is not null) PhoneNumber = phoneNumber;
        }

        public void UpdateExtraData(string? bio, string? linkedInUrl)
        {
            if (bio is not null) Bio = bio;
            if (linkedInUrl is not null) LinkedInProfile = linkedInUrl;
        }

        public void UpdatePrivacyConfiguration(bool? isPublic)
        {
            if (isPublic.HasValue) IsPublic = isPublic.Value;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void MarkAsDeleted()
        {
            IsDeleted = true;
            IsActive = false;
        }

        public void RegenerateSecurityStamp()
        {
            SecurityStamp = GenerateStamp();
        }

        private static string GenerateStamp()
        {
            var bytes = RandomNumberGenerator.GetBytes(32);
            return Convert.ToBase64String(bytes);
        }
    }
}
