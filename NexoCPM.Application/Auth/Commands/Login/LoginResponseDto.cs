using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Auth.Commands.Login
{
    public class LoginResponseDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string? RefreshToken { get; set; }
    }
}
