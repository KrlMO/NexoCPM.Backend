using MediatR;

namespace NexoCPM.Application.Auth.Commands.RequestPasswordReset
{
    public record RequestPasswordResetCommand(string Email, string IpAddress, string DeviceInfo)
        : IRequest<RequestPasswordResetResult>;
}
