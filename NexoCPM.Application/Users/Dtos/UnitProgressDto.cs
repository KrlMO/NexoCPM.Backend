namespace NexoCPM.Application.Users.Dtos
{
    public class UnitProgressDto
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; } = string.Empty;
        public decimal CompletedPercentage { get; set; }
    }
}
