using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NexoCPM.Application.Auth.Ports;
using NexoCPM.Application.Commons.Ports;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Infraestructure.Configurations;
using NexoCPM.Infraestructure.Security;
using NexoCPM.Infraestructure.Services.Auth;
using NexoCPM.Infraestructure.Services.Users;

namespace NexoCPM.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<BrevoSettings>(configuration.GetSection("Brevo"));

            services.AddScoped<IJwtService, JwtService>(provider => new JwtService(configuration));
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ITokenHasher, TokenHasher>();
            services.AddScoped<IUserCodeGenerator, UserCodeGenerator>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IEmailVerificationTokenService, EmailVerificationTokenService>();
            services.AddScoped<IPasswordResetTokenService, PasswordResetTokenService>();

            return services;
        }
    }
}
