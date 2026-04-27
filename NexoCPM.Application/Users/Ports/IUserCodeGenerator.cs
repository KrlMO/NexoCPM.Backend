using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Ports
{
    public interface IUserCodeGenerator
    {
        Task<string> GenerateAsync(string firstName, string lastName);
    }
}
