using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Commons.Ports
{
    public interface IEmailService
    {
        Task SendVerificationEmailAsync(string toEmail, string token);
    }
}
