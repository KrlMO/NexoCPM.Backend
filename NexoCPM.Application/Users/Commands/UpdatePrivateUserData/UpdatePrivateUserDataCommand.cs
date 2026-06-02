using MediatR;

namespace NexoCPM.Application.Users.Commands.UpdatePrivateUserData
{
    public record UpdatePrivateUserDataCommand(DateOnly? dateOfBirth, string? phoneNumber) : IRequest<UpdatePrivateUserDataResult>
    {
        public int UserId { get; init; }
    }
}
