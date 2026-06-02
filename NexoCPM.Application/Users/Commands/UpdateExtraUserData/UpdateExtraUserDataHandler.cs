using MediatR;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Common.Exceptions;

namespace NexoCPM.Application.Users.Commands.UpdateExtraUserData
{
    public class UpdateExtraUserDataHandler : IRequestHandler<UpdateExtraUserDataCommand, UpdateExtraUserDataResult>
    {
        private readonly IUserRepository _userRepository;

        public UpdateExtraUserDataHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UpdateExtraUserDataResult> Handle(UpdateExtraUserDataCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user is null)
                throw new NotFoundException("Usuario no encontrado");

            user.UpdateExtraData(request.bio, request.linkedInUrl);
            user.SetUpdated(request.UserId);
            await _userRepository.UpdateAsync(user);

            return new UpdateExtraUserDataResult
            {
                Bio = user.Bio,
                LinkedInProfile = user.LinkedInProfile
            };
        }
    }
}
