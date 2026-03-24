using NexoCPM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Entities.Users
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; }  = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole UserRole { get; set; }
        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }

        public ICollection<UserProgress> UserProgresses { get; set; } = new HashSet<UserProgress>();
        public ICollection<UserModuleProgress> UserModuleProgresses { get; set; } = new HashSet<UserModuleProgress>();
        public ICollection<UserResourceView> UserResourceViews { get; set; } = new HashSet<UserResourceView>();
        public ICollection<UserAssessmentResult> UserAssessmentResults { get; set; } = new HashSet<UserAssessmentResult>();

        public User() { }
    }
}
