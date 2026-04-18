using NexoCPM.Infraestructure.Security;
using Microsoft.Extensions.DependencyInjection;
using NexoCPM.Application.Auth.Ports;
using NexoCPM.Application.Commons.Ports;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
