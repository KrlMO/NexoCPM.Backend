using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Auth.Commands.ResendEmailVerification
{
    public record ResendEmailVerificationCommand(string Email) : IRequest<ResendEmailVerificationResult>;
    
}
