using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NexoCPM.Application.Auth.Ports;
using NexoCPM.Application.Context.Ports;
using NexoCPM.Application.Curriculum.Ports;
using NexoCPM.Application.Evaluations.Ports;
using NexoCPM.Application.Interfaces;
using NexoCPM.Application.Resources.Ports;
using NexoCPM.Application.Users.Ports;
using NexoCPM.Persistence.Context;
using NexoCPM.Persistence.Repositories.Auth;
using NexoCPM.Persistence.Repositories.Context;
using NexoCPM.Persistence.Repositories.Curriculum;
using NexoCPM.Persistence.Repositories.Evaluations;
using NexoCPM.Persistence.Repositories.Resources;
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

            services.AddScoped<IModalityRepository, ModalityRepository>();
            services.AddScoped<ILevelRepository, LevelRepository>();
            services.AddScoped<ISpecializationRepository, SpecializationRepository>();
            services.AddScoped<IAssessmentAttemptRepository, AssessmentAttemptRepository>();
            services.AddScoped<IAssessmentRepository, AssessmentRepository>();
            services.AddScoped<ISyllabusRepository, SyllabusRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserLeaderboardRepository, UserLeaderboardRepository>();
            services.AddScoped<IUserSubTopicViewRepository, UserSubTopicViewRepository>();
            services.AddScoped<IUserProgressRepository, UserProgressRepository>();
            services.AddScoped<IUserLearningContextRepository, UserLearningContextRepository>();
            services.AddScoped<ISyllabusUnitRepository, SyllabusUnitRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddScoped<IEmailVerificationTokenRepository, EmailVerificationTokenRepository>();
            services.AddScoped<IResourceRepository, ResourceRepository>();
            services.AddScoped<ISubTopicRepository, SubTopicRepository>();
            services.AddScoped<IMicroTopicRepository, MicroTopicRepository>();
            services.AddScoped<ICompetenceRepository, CompetenceRepository>();
            services.AddScoped<ICompetenceLevelRepository, CompetenceLevelRepository>();
            services.AddScoped<IAbilityRepository, AbilityRepository>();

            return services;
        }
    }
}
