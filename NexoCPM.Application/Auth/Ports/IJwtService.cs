using NexoCPM.Domain.Users.Entities;
using System.Security.Claims;

namespace NexoCPM.Application.Auth.Ports
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        ClaimsPrincipal DecodeToken(string token);
    }
}
