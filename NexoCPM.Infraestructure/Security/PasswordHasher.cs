using BCrypt.Net;
using NexoCPM.Application.Commons.Ports;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Infraestructure.Security
{
    public class PasswordHasher: IPasswordHasher
    {
        public string Hash(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool Verify(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }
    }
}
