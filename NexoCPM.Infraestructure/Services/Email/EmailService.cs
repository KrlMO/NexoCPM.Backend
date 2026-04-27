using NexoCPM.Application.Commons.Ports;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Infraestructure.Services.Auth
{
    public class EmailService : IEmailService
    {
        public async Task SendVerificationEmailAsync(string toEmail, string token)
        {
            Console.WriteLine($"Enviar correo a {toEmail} con token {token}");
        }
    }
}
