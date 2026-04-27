using Microsoft.IdentityModel.Tokens;
using NexoCPM.Application.Auth.Ports;
using NexoCPM.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace NexoCPM.Infraestructure.Security
{
    public class JwtService : IJwtService
    {
        private readonly string _secret;

        public JwtService(IConfiguration config)
        {
            if (config == null) throw new ArgumentNullException(nameof(config));
            var secret = config["Jwt:Secret"];
            _secret = secret ?? throw new ArgumentNullException("Jwt:Secret", "JWT secret configuration missing");
        }

        public string GenerateToken(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.UserRole.ToString())
            };

            var token = new JwtSecurityToken(
                issuer: "nexo",
                audience: "nexo",
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
