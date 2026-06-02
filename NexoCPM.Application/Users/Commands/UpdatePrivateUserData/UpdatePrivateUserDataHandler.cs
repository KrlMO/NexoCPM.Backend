using MediatR;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Common.Exceptions;

namespace NexoCPM.Application.Users.Commands.UpdatePrivateUserData
{
    public class UpdatePrivateUserDataHandler : IRequestHandler<UpdatePrivateUserDataCommand, UpdatePrivateUserDataResult>
    {
        private readonly IUserRepository _userRepository;

        public UpdatePrivateUserDataHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UpdatePrivateUserDataResult> Handle(UpdatePrivateUserDataCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user is null)
                throw new NotFoundException("Usuario no encontrado");

            user.UpdatePrivateData(request.dateOfBirth, request.phoneNumber);
            user.SetUpdated(request.UserId);
            await _userRepository.UpdateAsync(user);

            return new UpdatePrivateUserDataResult
            {
                DateOfBirth = user.DateOfBirth,
                PhoneNumber = user.PhoneNumber
            };
        }
    }
}
