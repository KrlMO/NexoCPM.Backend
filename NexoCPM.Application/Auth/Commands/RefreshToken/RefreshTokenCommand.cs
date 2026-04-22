using MediatR;

namespace NexoCPM.Application.Auth.Commands.RefreshToken
{
    public record RefreshTokenCommand(string RefreshToken, string DeviceInfo, string IpAddress) : IRequest<RefreshTokenResponseDto>;
}