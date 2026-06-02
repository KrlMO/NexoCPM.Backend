using MediatR;
using NexoCPM.Application.Auth.Ports;
using NexoCPM.Application.Commons.Ports;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Common.Exceptions;

namespace NexoCPM.Application.Users.Commands.ChangePassword;

public class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, ChangePasswordResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IRefreshTokenRepository _refreshTokenRepository;

    public ChangePasswordHandler(
        IUserRepository userRepository,
        IPasswordHasher passwordHasher,
        IRefreshTokenRepository refreshTokenRepository)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<ChangePasswordResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user is null)
            throw new NotFoundException("Usuario no encontrado");

        if (!_passwordHasher.Verify(request.CurrentPassword, user.GetPasswordHash()))
            throw new UnauthorizedException("La contraseña actual no es correcta");

        var newHash = _passwordHasher.Hash(request.NewPassword);
        user.ChangePassword(newHash);
        await _userRepository.UpdateAsync(user);

        await _refreshTokenRepository.RevokeAllByUserIdAsync(request.UserId);

        return new ChangePasswordResponse
        {
            Message = "Contraseña cambiada correctamente"
        };
    }
}
