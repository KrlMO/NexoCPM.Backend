using Microsoft.EntityFrameworkCore;
using NexoCPM.Application.Interfaces;
using NexoCPM.Domain.Auth.Entities;
using NexoCPM.Domain.Context.Entities;
using NexoCPM.Domain.Curriculum.Entities;
using NexoCPM.Domain.Evaluations.Entities;
using NexoCPM.Domain.Resources.Entities;
using NexoCPM.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace NexoCPM.Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }

        public DbSet<User> Users => Set<User>();

        public DbSet<EmailVerificationToken> EmailVerificationTokens => Set<EmailVerificationToken>();

        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();

        public DbSet<Competence> Competences => Set<Competence>();

        public DbSet<EducationContext> EducationContexts => Set<EducationContext>();

        public DbSet<Level> Levels => Set<Level>();

        public DbSet<Modality> Modalities => Set<Modality>();

        public DbSet<Specialization> Specializations => Set<Specialization>();

        public DbSet<Syllabus> Syllabi => Set<Syllabus>();

        public DbSet<SyllabusContext> SyllabusContexts => Set<SyllabusContext>();

        public DbSet<Topic> SyllabusTopics => Set<Topic>();

        public DbSet<SyllabusUnit> SyllabusUnits => Set<SyllabusUnit>();

        public DbSet<SubTopic> Topics => Set<SubTopic>();

        public DbSet<AssessmentAttempt> AssessmentAttempts => Set<AssessmentAttempt>();

        public DbSet<AssessmentAttemptQuestion> AssessmentAttemptQuestions => Set<AssessmentAttemptQuestion>();
        public DbSet<Assessment> Assessments => Set<Assessment>();

        public DbSet<Question> Questions => Set<Question>();


        public DbSet<Resource> Resources => Set<Resource>();

        public DbSet<UserResourceView> UserResourceViews => Set<UserResourceView>();

        public DbSet<UserSyllabusProgress> UserSyllabusProgresses => Set<UserSyllabusProgress>();

        public DbSet<UserSyllabusUnitProgress> UserSyllabusUnitProgresses => Set<UserSyllabusUnitProgress>();

        public DbSet<Option> Options => Set<Option>();

        public DbSet<SubTopic> SubTopics => Set<SubTopic>();

        public DbSet<CompetenceLevel> CompetenceLevels => Set<CompetenceLevel>();

        public DbSet<CompetenceLevelUnit> CompetenceLevelUnits => Set<CompetenceLevelUnit>();

        public DbSet<MicroTopic> MicroTopics => Set<MicroTopic>();
        public DbSet<QuestionContentBlock> QuestionContentBlocks => Set<QuestionContentBlock>();

        public DbSet<ResourceLike> ResourceLikes => Set<ResourceLike>();

        public DbSet<UserLearningContext> UserLearningContexts => Set<UserLearningContext>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
