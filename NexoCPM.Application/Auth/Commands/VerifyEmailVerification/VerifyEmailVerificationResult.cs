using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Auth.Commands.VerifyEmailVerification
{
    public class VerifyEmailVerificationResult
    {
        public bool IsUsed { get; set; }
        public int TimeToResendSeconds { get; set; } = 0;
        public bool EmailVerified { get; set; } = false;
        public bool EmailExists { get; set; } = false;
        public bool CanResend { get; set; } = false;
    }
}
