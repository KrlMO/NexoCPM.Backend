using System.Security.Cryptography;
using System.Text;
using NexoCPM.Application.Commons.Ports;

namespace NexoCPM.Infraestructure.Security;

public class TokenHasher : ITokenHasher
{
    public string Hash(string token)
    {
        using var sha256 = SHA256.Create();
        var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(token));
        return Convert.ToBase64String(hashBytes);
    }
}
