using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Common.Exceptions
{
    public class TokenExpiredException : DomainException
    {
        public TokenExpiredException()
            : base("El token ha expirado", StatusCodes.Status400BadRequest)
        {
        }
    }
}
