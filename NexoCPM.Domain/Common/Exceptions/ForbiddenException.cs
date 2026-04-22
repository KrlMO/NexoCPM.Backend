using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Common.Exceptions
{
    public class ForbiddenException : DomainException
    {
        public ForbiddenException(string message)
            : base(message, StatusCodes.Status403Forbidden)
        {
        }
    }
}
