using NexoCPM.Application.Users.Ports;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Infraestructure.Services.Users
{
    public class UserCodeGenerator : IUserCodeGenerator
    {
        private readonly IUserRepository _userRepository;

        public UserCodeGenerator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string> GenerateAsync(string firstName, string lastName)
        {
            string code;

            do
            {
                var prefix = (firstName[..2] + lastName[..2]).ToUpper();
                var randomPart = Guid.NewGuid().ToString("N")[..6].ToUpper();

                code = $"{prefix}-{randomPart}";
            }
            while (await _userRepository.ExistsByCodeAsync(code));

            return code;
        }
    }
}
