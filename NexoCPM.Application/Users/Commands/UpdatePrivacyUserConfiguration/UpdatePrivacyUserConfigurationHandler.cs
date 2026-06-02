using MediatR;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Common.Exceptions;

namespace NexoCPM.Application.Users.Commands.UpdatePrivacyUserConfiguration
{
    public class UpdatePrivacyUserConfigurationHandler : IRequestHandler<UpdatePrivacyUserConfigurationCommand, UpdatePrivacyUserConfigurationResult>
    {
        private readonly IUserRepository _userRepository;

        public UpdatePrivacyUserConfigurationHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UpdatePrivacyUserConfigurationResult> Handle(UpdatePrivacyUserConfigurationCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user is null)
                throw new NotFoundException("Usuario no encontrado");

            user.UpdatePrivacyConfiguration(request.isPublic);
            user.SetUpdated(request.UserId);
            await _userRepository.UpdateAsync(user);

            return new UpdatePrivacyUserConfigurationResult
            {
                IsPublic = user.IsPublic
            };
        }
    }
}
