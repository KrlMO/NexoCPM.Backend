using MediatR;
using NexoCPM.Application.Auth.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Auth.Commands.Login
{
    public record LoginCommand(string Email, string Password, string IpAddress, string DeviceInfo) : IRequest<LoginResult>;
}
