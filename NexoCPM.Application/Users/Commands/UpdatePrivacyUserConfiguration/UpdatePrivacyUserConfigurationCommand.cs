using MediatR;

namespace NexoCPM.Application.Users.Commands.UpdatePrivacyUserConfiguration
{
    public record UpdatePrivacyUserConfigurationCommand(bool? isPublic) : IRequest<UpdatePrivacyUserConfigurationResult>
    {
        public int UserId { get; init; }
    }
}
