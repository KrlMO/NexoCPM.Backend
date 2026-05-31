namespace NexoCPM.Application.Auth.Ports
{
    public interface IPasswordResetTokenService
    {
        Task<(string token, string tokenHash)> GenerateAsync();
    }
}
