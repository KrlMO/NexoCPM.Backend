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

        public EmailService(IOptions<BrevoSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendVerificationEmailAsync(string toEmail, string token)
        {
            var verificationLink = $"{_settings.FrontendUrl.TrimEnd('/')}/auth/verify-account?token={Uri.EscapeDataString(token)}&email={Uri.EscapeDataString(toEmail)}";

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_settings.SenderName, _settings.SenderEmail));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = "Verifica tu correo electrónico - NexoCPM";
            var body = $"""
                <!DOCTYPE html>
                <html>
                <head><meta charset="utf-8"></head>
                <body style="font-family: Arial, sans-serif; padding: 20px;">
                    <h2>¡Bienvenido a NexoCPM!</h2>
                    <p>Gracias por registrarte. Para completar tu registro, por favor verifica tu correo electrónico haciendo clic en el siguiente enlace:</p>
                    <p><a href="{verificationLink}" style="display: inline-block; padding: 12px 24px; background-color: #4F46E5; color: white; text-decoration: none; border-radius: 6px;">Verificar correo electrónico</a></p>
                    <p>Si el botón no funciona, copia y pega el siguiente enlace en tu navegador:</p>
                    <p><small>{verificationLink}</small></p>
                    <p>Este enlace expirará en 24 horas.</p>
                    <p>Si no creaste esta cuenta, ignora este mensaje.</p>
                </body>
                </html>
                """;

            message.Body = new BodyBuilder
            {
                HtmlBody = body,
                TextBody = $"Verifica tu correo: {verificationLink}"
            }.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync(_settings.Host, _settings.Port, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_settings.SmtpLogin, _settings.SmtpPassword);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
