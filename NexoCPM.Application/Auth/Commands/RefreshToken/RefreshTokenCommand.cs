using MediatR;
using NexoCPM.Application.Auth.Dtos;

namespace NexoCPM.Application.Auth.Commands.RefreshToken
{
    public record RefreshTokenCommand(string RefreshToken, string DeviceInfo, string IpAddress) : IRequest<RefreshTokenResult>;
}