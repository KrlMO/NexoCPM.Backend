using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Commons.Ports
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string password, string hash);
    }
}
