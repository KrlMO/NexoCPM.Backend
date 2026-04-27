namespace NexoCPM.Application.Auth.Dtos
{
    public class RefreshTokenResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public AuthUserDto User { get; set; } = null!;
    }
}