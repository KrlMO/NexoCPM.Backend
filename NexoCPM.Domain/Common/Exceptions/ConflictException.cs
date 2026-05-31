using Microsoft.AspNetCore.Http;

namespace NexoCPM.Domain.Common.Exceptions
{
    public class ConflictException : DomainException
    {
        public ConflictException(string message)
            : base(message, StatusCodes.Status409Conflict)
        {
        }
    }
}
