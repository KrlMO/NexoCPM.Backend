using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Common.Exceptions
{
    public class UnauthorizedException : DomainException
    {
        public UnauthorizedException(string message)
            : base(message, StatusCodes.Status401Unauthorized)
        {
        }
    }
}
