using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Auth.Commands.Register
{
    public record RegisterCommand(string FirstName, string LastName, string UserName, string Email, string Password) : IRequest<RegisterResult>;
}
