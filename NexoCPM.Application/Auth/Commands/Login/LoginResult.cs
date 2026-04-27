using NexoCPM.Application.Auth.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Auth.Commands.Login
{
    public class LoginResult
    {
        public string? RefreshToken { get; set; }
        public string AccessToken { get; set; } = string.Empty;
        public AuthUserDto User { get; set; } = null!;
    }
}
