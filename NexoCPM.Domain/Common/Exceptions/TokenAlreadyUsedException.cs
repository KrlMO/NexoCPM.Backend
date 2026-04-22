using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Common.Exceptions
{
    public class TokenAlreadyUsedException : DomainException
    {
        public TokenAlreadyUsedException()
            : base("El token ya fue utilizado", StatusCodes.Status400BadRequest)
        {
        }
    }
}
