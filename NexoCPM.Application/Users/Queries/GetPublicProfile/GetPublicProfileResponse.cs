namespace NexoCPM.Application.Users.Queries.GetPublicProfile
{
    public class GetPublicProfileResponse
    {
        public bool IsPrivate { get; set; }
        public bool NotFound { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Code { get; set; }
        public string? Bio { get; set; }
        public string? LinkedInProfile { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public int TotalStars { get; set; }
    }
}
