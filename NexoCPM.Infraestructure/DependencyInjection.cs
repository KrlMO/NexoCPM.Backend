using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NexoCPM.Application.Auth.Ports;
using NexoCPM.Application.Commons.Ports;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Infraestructure.Security;
using NexoCPM.Infraestructure.Services.Auth;
using NexoCPM.Infraestructure.Services.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJwtService, JwtService>(provider => new JwtService(configuration));
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IUserCodeGenerator, UserCodeGenerator>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IEmailVerificationTokenService, EmailVerificationTokenService>();

            return services;
        }
    }
}
