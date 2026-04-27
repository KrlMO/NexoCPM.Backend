using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Commons.Exceptions
{
    public class UniqueConstraintException : Exception
    {
        public UniqueConstraintException(string message) : base(message) { }
    }
}
