using NexoCPM.Application.Auth.Ports;
using System.Security.Cryptography;

namespace NexoCPM.Infraestructure.Services.Auth
{
    public class PasswordResetTokenService : IPasswordResetTokenService
    {
        public Task<(string token, string tokenHash)> GenerateAsync()
        {
            var bytes = RandomNumberGenerator.GetBytes(32);
            var token = Convert.ToBase64String(bytes);

            using var sha256 = SHA256.Create();
            var hashBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(token));
            var tokenHash = Convert.ToBase64String(hashBytes);

            return Task.FromResult((token, tokenHash));
        }
    }
}
