using NexoCPM.Domain.Common;
using NexoCPM.Domain.Entities.Auth;
using NexoCPM.Domain.Entities.Evaluations;
using NexoCPM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Users
{
    public class User : AuditableEntity
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; }  = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole UserRole { get; set; }
        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<UserSyllabusUnitProgress> UserSyllabusUnitProgresses { get; set; } = new List<UserSyllabusUnitProgress>();
        public ICollection<UserSyllabusProgress> UserSyllabusProgresses { get; set; } = new HashSet<UserSyllabusProgress>();
        public ICollection<UserResourceView> UserResourceViews { get; set; } = new HashSet<UserResourceView>();
        public ICollection<UserAssessmentResult> UserAssessmentResults { get; set; } = new HashSet<UserAssessmentResult>();
        public ICollection<AssesmentAttempt> AssesmentAttempts { get; set; } = new HashSet<AssesmentAttempt>();
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
        public ICollection<EmailVerificationToken>? EmailVerificationTokens { get; set; } = new HashSet<EmailVerificationToken>();

        public User() { }
    }
}
