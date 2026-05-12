namespace NexoCPM.Application.Users.Dtos
{
    public class MySyllabusDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateOnly LastAccess { get; set; }
        public decimal CompletedPercentage { get; set; }
        public int UserLearningContextId { get; set; }
    }
}
