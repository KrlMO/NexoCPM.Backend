namespace NexoCPM.Infraestructure.Configurations
{
    public class BrevoSettings
    {
        public string Host { get; set; } = default!;
        public int Port { get; set; }
        public string SmtpLogin { get; set; } = default!;
        public string SmtpPassword { get; set; } = default!;
        public string SenderEmail { get; set; } = default!;
        public string SenderName { get; set; } = default!;
        public string FrontendUrl { get; set; } = default!;
    }
}
