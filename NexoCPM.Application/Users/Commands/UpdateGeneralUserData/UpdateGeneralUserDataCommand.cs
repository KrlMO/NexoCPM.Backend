using MediatR;

namespace NexoCPM.Application.Users.Commands.UpdateGeneralUserData
{
    public record UpdateGeneralUserDataCommand(string? firstName, string? lastName, string? userName) : IRequest<UpdateGeneralUserDataResult>
    {
        public int UserId { get; init; }
    }
}
