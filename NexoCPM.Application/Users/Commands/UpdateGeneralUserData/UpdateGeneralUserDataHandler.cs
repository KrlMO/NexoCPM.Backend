using MediatR;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Common.Exceptions;

namespace NexoCPM.Application.Users.Commands.UpdateGeneralUserData
{
    public class UpdateGeneralUserDataHandler : IRequestHandler<UpdateGeneralUserDataCommand, UpdateGeneralUserDataResult>
    {
        private readonly IUserRepository _userRepository;

        public UpdateGeneralUserDataHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UpdateGeneralUserDataResult> Handle(UpdateGeneralUserDataCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user is null)
                throw new NotFoundException("Usuario no encontrado");

            if (request.userName is not null && request.userName != user.UserName)
            {
                var existing = await _userRepository.GetByUserNameAsync(request.userName);
                if (existing is not null)
                    throw new ConflictException("El nombre de usuario ya está en uso");
            }

            user.UpdateGeneralData(request.firstName, request.lastName, request.userName);
            user.SetUpdated(request.UserId);
            await _userRepository.UpdateAsync(user);

            return new UpdateGeneralUserDataResult
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName
            };
        }
    }
}
