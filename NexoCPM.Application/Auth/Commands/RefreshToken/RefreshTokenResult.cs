using NexoCPM.Application.Auth.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Auth.Commands.RefreshToken
{
    public class RefreshTokenResult
    {
        public string AccessToken { get; set; } = string.Empty;
        public string? RefreshToken { get; set; }
        public AuthUserDto User { get; set; } = null!;
    }
}
