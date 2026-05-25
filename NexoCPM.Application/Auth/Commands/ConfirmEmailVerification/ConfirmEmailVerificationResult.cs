namespace NexoCPM.Application.Auth.Commands.ConfirmEmailVerification
{
    public class ConfirmEmailVerificationResult
    {
        public bool emailConfirmed { get; }
        public string Email { get; }

        public ConfirmEmailVerificationResult(bool success, string email)
        {
            emailConfirmed = success;
            Email = email;
        }
    }
}
