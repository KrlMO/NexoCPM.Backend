using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Auth.Commands.VerifyEmailVerification
{
    public record VerifyEmailVerificationCommand(string email) : IRequest<VerifyEmailVerificationResult>;
}
