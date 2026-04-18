using NexoCPM.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Auth.Ports
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
