using MediatR;

namespace NexoCPM.Application.Users.Commands.UpdateExtraUserData
{
    public record UpdateExtraUserDataCommand(string? bio, string? linkedInUrl) : IRequest<UpdateExtraUserDataResult>
    {
        public int UserId { get; init; }
    }
}
