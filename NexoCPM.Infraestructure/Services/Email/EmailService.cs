using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using NexoCPM.Application.Commons.Ports;
using NexoCPM.Infraestructure.Configurations;

namespace NexoCPM.Infraestructure.Services.Auth
{
    public class EmailService : IEmailService
    {
        private readonly BrevoSettings _settings;
        private static readonly string TemplatesPath = Path.Combine(
            AppContext.BaseDirectory, "Services", "Email", "EmailTemplates");

        public EmailService(IOptions<BrevoSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendPasswordResetEmailAsync(string toEmail, string token)
        {
            var actionUrl = $"{_settings.FrontendUrl.TrimEnd('/')}/auth/reset-password?token={Uri.EscapeDataString(token)}&email={Uri.EscapeDataString(toEmail)}";
            var html = await LoadTemplateAsync("PasswordReset.html.html", actionUrl);

            var message = BuildMessage(toEmail, "Recuperación de contraseña - NexoCPM", html, $"Restablece tu contraseña: {actionUrl}");
            await SendAsync(message);
        }

        public async Task SendVerificationEmailAsync(string toEmail, string token)
        {
            var actionUrl = $"{_settings.FrontendUrl.TrimEnd('/')}/auth/verify-account?token={Uri.EscapeDataString(token)}&email={Uri.EscapeDataString(toEmail)}";
            var html = await LoadTemplateAsync("VerifyEmail.html", actionUrl);

            var message = BuildMessage(toEmail, "Verifica tu correo electrónico - NexoCPM", html, $"Verifica tu correo: {actionUrl}");
            await SendAsync(message);
        }

        private static async Task<string> LoadTemplateAsync(string fileName, string actionUrl)
        {
            var filePath = Path.Combine(TemplatesPath, fileName);
            var template = await File.ReadAllTextAsync(filePath);
            return template.Replace("{{actionUrl}}", actionUrl);
        }

        private MimeMessage BuildMessage(string toEmail, string subject, string htmlBody, string textBody)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_settings.SenderName, _settings.SenderEmail));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;
            message.Body = new BodyBuilder
            {
                HtmlBody = htmlBody,
                TextBody = textBody
            }.ToMessageBody();
            return message;
        }

        private async Task SendAsync(MimeMessage message)
        {
            using var client = new SmtpClient();
            await client.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_settings.SmtpLogin, _settings.SmtpPassword);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
