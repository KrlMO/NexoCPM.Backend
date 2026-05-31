using System.ComponentModel.DataAnnotations;

namespace NexoCPM.Api.Controllers.Auth.Requests
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
