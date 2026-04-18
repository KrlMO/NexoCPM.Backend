using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using NexoCPM.Domain.Auth.Entities;
using NexoCPM.Domain.Context.Entities;
using NexoCPM.Domain.Curriculum.Entities;
using NexoCPM.Domain.Evaluations.Entities;
using NexoCPM.Domain.Resources.Entities;
using NexoCPM.Domain.Users.Entities;

namespace NexoCPM.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        //Auth
        DbSet<EmailVerificationToken> EmailVerificationTokens { get; }
        DbSet<RefreshToken> RefreshTokens { get; }

        //Context
        DbSet<Competence> Competences { get; }
        DbSet<CompetenceSyllabusTopic> CompetenceSyllabusTopics { get; }
        DbSet<EducationContext> EducationContexts { get; }
        DbSet<Level> Levels { get; }
        DbSet<Modality> Modalities { get; }
        DbSet<Specialization> Specializations { get; }

        //Curriculum
        DbSet<Syllabus> Syllabi { get; }
        DbSet<SyllabusContext> SyllabusContexts { get; }
        DbSet<SyllabusTopic> SyllabusTopics { get; }
        DbSet<SyllabusUnit> SyllabusUnits { get; }
        DbSet<Topic> Topics { get; }

        //Evaluation
        DbSet<AnswerOption> AnswerOptions { get; }
        DbSet<AssesmentAttempt> AssesmentAttempts { get; }
        DbSet<AssesmentAttemptQuestion> AssesmentAttemptQuestions { get; }
        DbSet<Assesment> Assessments { get; }
        DbSet<Question> Questions { get; }
        DbSet<QuestionTopic> QuestionTopics { get; }

        //Resources
        DbSet<Resource> Resources { get; }

        // Users
        DbSet<User> Users { get; }
        DbSet<UserAnswer> UserAnswers { get; }
        DbSet<UserResourceView> UserResourceViews { get; }
        DbSet<UserSyllabusProgress> UserSyllabusProgresses { get; }
        DbSet<UserSyllabusUnitProgress> UserSyllabusUnitProgresses { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
