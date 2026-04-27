namespace NexoCPM.Application.Auth.Commands.Register;

public class RegisterResult
{
    public bool EmailSent { get; set; }
    public string Message { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}