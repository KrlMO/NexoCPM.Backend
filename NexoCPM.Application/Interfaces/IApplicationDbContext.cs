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
        DbSet<PasswordResetToken> PasswordResetTokens { get; }

        //Context
        DbSet<Competence> Competences { get; }
        DbSet<CompetenceLevel> CompetenceLevels { get; }
        DbSet<EducationContext> EducationContexts { get; }
        DbSet<Level> Levels { get; }
        DbSet<Modality> Modalities { get; }
        DbSet<Specialization> Specializations { get; }

        //Curriculum
        DbSet<MicroTopic> MicroTopics { get; }
        DbSet<SubTopic> SubTopics { get; }
        DbSet<Syllabus> Syllabi { get; }
        DbSet<SyllabusContext> SyllabusContexts { get; }
        DbSet<SyllabusUnit> SyllabusUnits { get; }
        DbSet<Topic> SyllabusTopics { get; }

        //Evaluation
        DbSet<Assessment> Assessments { get; }
        DbSet<AssessmentAttempt> AssessmentAttempts { get; }
        DbSet<AssessmentAttemptQuestion> AssessmentAttemptQuestions { get; }
        DbSet<Option> Options{ get; }
        DbSet<Question> Questions { get; }
        DbSet<QuestionContentBlock> QuestionContentBlocks { get; }
        DbSet<OptionBlock> OptionBlocks { get; }
        DbSet<QuestionContext> QuestionContexts { get; }

        //Resources
        DbSet<Resource> Resources { get; }
        DbSet<ResourceLike> ResourceLikes { get; }

        // Users
        DbSet<User> Users { get; }
        DbSet<UserLearningContext> UserLearningContexts { get; }
        DbSet<UserResourceView> UserResourceViews { get; }
        DbSet<UserSyllabusProgress> UserSyllabusProgresses { get; }
        DbSet<UserSyllabusUnitProgress> UserSyllabusUnitProgresses { get; }
        DbSet<UserSubTopicView> UserSubTopicViews { get; }
        DbSet<UserLeaderboard> UserLeaderboards { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
