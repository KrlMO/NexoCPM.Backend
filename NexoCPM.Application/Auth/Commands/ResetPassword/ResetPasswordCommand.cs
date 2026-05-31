using MediatR;

namespace NexoCPM.Application.Auth.Commands.ResetPassword
{
    public record ResetPasswordCommand(string Email, string Token, string NewPassword)
        : IRequest<ResetPasswordResult>;
}
