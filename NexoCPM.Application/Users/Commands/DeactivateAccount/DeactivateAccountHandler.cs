using MediatR;
using NexoCPM.Application.Auth.Ports;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Common.Exceptions;

namespace NexoCPM.Application.Users.Commands.DeactivateAccount
{
    public class DeactivateAccountHandler : IRequestHandler<DeactivateAccountCommand, DeactivateAccountResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public DeactivateAccountHandler(IUserRepository userRepository, IRefreshTokenRepository refreshTokenRepository)
        {
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<DeactivateAccountResult> Handle(DeactivateAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user is null)
                throw new NotFoundException("Usuario no encontrado");

            if (!user.IsActive)
                throw new ConflictException("La cuenta ya está desactivada");

            user.Deactivate();
            user.SetUpdated(request.UserId);
            await _userRepository.UpdateAsync(user);

            await _refreshTokenRepository.RevokeAllByUserIdAsync(request.UserId);

            return new DeactivateAccountResult
            {
                Message = "Cuenta desactivada correctamente"
            };
        }
    }
}
