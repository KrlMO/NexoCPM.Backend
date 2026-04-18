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

        public DbSet<CompetenceSyllabusTopic> CompetenceSyllabusTopics => Set<CompetenceSyllabusTopic>();

        public DbSet<EducationContext> EducationContexts => Set<EducationContext>();

        public DbSet<Level> Levels => Set<Level>();

        public DbSet<Modality> Modalities => Set<Modality>();

        public DbSet<Specialization> Specializations => Set<Specialization>();

        public DbSet<Syllabus> Syllabi => Set<Syllabus>();

        public DbSet<SyllabusContext> SyllabusContexts => Set<SyllabusContext>();

        public DbSet<SyllabusTopic> SyllabusTopics => Set<SyllabusTopic>();

        public DbSet<SyllabusUnit> SyllabusUnits => Set<SyllabusUnit>();

        public DbSet<Topic> Topics => Set<Topic>();
        public DbSet<AnswerOption> AnswerOptions => Set<AnswerOption>();

        public DbSet<AssesmentAttempt> AssesmentAttempts => Set<AssesmentAttempt>();

        public DbSet<AssesmentAttemptQuestion> AssesmentAttemptQuestions => Set<AssesmentAttemptQuestion>();
        public DbSet<Assesment> Assessments => Set<Assesment>();

        public DbSet<Question> Questions => Set<Question>();

        public DbSet<QuestionTopic> QuestionTopics => Set<QuestionTopic>();

        public DbSet<Resource> Resources => Set<Resource>();

        public DbSet<UserAnswer> UserAnswers => Set<UserAnswer>();
        public DbSet<UserResourceView> UserResourceViews => Set<UserResourceView>();

        public DbSet<UserSyllabusProgress> UserSyllabusProgresses => Set<UserSyllabusProgress>();

        public DbSet<UserSyllabusUnitProgress> UserSyllabusUnitProgresses => Set<UserSyllabusUnitProgress>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
