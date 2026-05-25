using System.ComponentModel.DataAnnotations;

namespace NexoCPM.Api.Controllers.Auth.Requests
{
    public class ConfirmEmailVerificationRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Token { get; set; } = string.Empty;
    }
}
