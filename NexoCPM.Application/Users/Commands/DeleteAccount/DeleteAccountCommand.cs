using MediatR;

namespace NexoCPM.Application.Users.Commands.DeleteAccount
{
    public record DeleteAccountCommand() : IRequest<DeleteAccountResult>
    {
        public int UserId { get; init; }
    }
}
