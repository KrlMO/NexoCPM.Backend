using MediatR;

namespace NexoCPM.Application.Users.Commands.DeactivateAccount
{
    public record DeactivateAccountCommand() : IRequest<DeactivateAccountResult>
    {
        public int UserId { get; init; }
    }
}
