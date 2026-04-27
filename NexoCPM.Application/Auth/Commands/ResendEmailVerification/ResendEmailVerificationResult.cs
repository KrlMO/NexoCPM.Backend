using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Auth.Commands.ResendEmailVerification
{
    public class ResendEmailVerificationResult
    {
        public bool Success { get; }

        public ResendEmailVerificationResult(bool success)
        {
            Success = success;
        }
    }
}
