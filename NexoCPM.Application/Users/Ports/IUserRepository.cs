using NexoCPM.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Application.Users.Ports
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByUserNameAsync(string userName);
        Task<User> AddAsync(User user);
        Task<bool> ExistsByCodeAsync(string code);
        Task UpdateAsync(User user);
    }
}
