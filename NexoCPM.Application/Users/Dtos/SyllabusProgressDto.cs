namespace NexoCPM.Application.Users.Dtos
{
    public class SyllabusProgressDto
    {
        public int UserLearningContextId { get; set; }
        public int UserSyllabusProgressId { get; set; }
        public string SyllabusName { get; set; } = string.Empty;
        public string SyllabusSlug { get; set; } = string.Empty;
        public decimal CompletedPercentage { get; set; }
    }
}
