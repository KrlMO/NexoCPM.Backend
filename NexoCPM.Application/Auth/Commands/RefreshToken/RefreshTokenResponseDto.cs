namespace NexoCPM.Application.Auth.Commands.RefreshToken
{
    public class RefreshTokenResponseDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string? RefreshToken { get; set; }
    }
}