using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Domain.Common.Exceptions
{
    public abstract class DomainException : Exception
    {
        public int StatusCode { get; }

        protected DomainException(string message, int statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
