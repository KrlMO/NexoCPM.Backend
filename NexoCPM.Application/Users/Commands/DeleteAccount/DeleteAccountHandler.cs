using MediatR;
using NexoCPM.Application.Auth.Ports;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Common.Exceptions;

namespace NexoCPM.Application.Users.Commands.DeleteAccount
{
    public class DeleteAccountHandler : IRequestHandler<DeleteAccountCommand, DeleteAccountResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public DeleteAccountHandler(IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository)
        {
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<DeleteAccountResult> Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user is null)
                throw new NotFoundException("Usuario no encontrado");

            if (user.IsDeleted)
                throw new ConflictException("La cuenta ya ha sido eliminada");

            user.MarkAsDeleted();
            user.SetDeleted(request.UserId);
            await _userRepository.UpdateAsync(user);

            await _refreshTokenRepository.RevokeAllByUserIdAsync(request.UserId);

            return new DeleteAccountResult
            {
                Message = "Cuenta eliminada correctamente"
            };
        }
    }
}
