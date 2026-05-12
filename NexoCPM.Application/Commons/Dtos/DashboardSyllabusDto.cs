namespace NexoCPM.Application.Commons.Dtos
{
    public class DashboardSyllabusDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LastUnitName { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public decimal CompletedPercentage { get; set; }
        public DateOnly LastActivity { get; set; }
    }
}

