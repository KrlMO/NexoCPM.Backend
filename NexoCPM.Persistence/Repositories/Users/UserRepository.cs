using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Commons.Exceptions;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Domain.Users.Entities;
using NexoCPM.Infraestructure.Persistence.Helper;
using NexoCPM.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && !u.IsDeleted);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted);
        }

        public async Task<User?> GetByUserNameAsync(string userName)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == userName && !u.IsDeleted);
        }

        public async Task<User> AddAsync(User user)
        {
            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (DbUpdateException ex)
                when (DbExceptionHelper.IsUniqueConstraint(ex, "IX_Users_Code"))
            {
                throw new UniqueConstraintException("El código ya existe");
            }
        }

        public async Task<bool> ExistsByCodeAsync(string code)
        {
            return await _context.Users
                .AnyAsync(u => u.Code == code);
        }
    }
}
