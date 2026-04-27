using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NexoCPM.Application.Auth.Ports;
using NexoCPM.Application.Interfaces;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Persistence.Context;
using NexoCPM.Persistence.Repositories.Auth;
using NexoCPM.Persistence.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsAssembly("NexoCPM.Persistence")
                ));

            services.AddScoped<IApplicationDbContext>(provider =>
                provider.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IApplicationDbContext>(
                provider => provider.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IEmailVerificationTokenRepository, EmailVerificationTokenRepository>();

            return services;
        }
    }
}
