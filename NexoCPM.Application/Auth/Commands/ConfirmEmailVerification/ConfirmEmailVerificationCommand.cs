using MediatR;

namespace NexoCPM.Application.Auth.Commands.ConfirmEmailVerification
{
    public record ConfirmEmailVerificationCommand(string Email, string Token) : IRequest<ConfirmEmailVerificationResult>;
}
