using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Interfaces;
using NexoCPM.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NexoCPM.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
