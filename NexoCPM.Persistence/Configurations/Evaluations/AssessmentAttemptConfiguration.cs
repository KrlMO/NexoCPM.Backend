using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Evaluations.Entities;

namespace NexoCPM.Persistence.Configurations.Evaluations;

public class AssessmentAttemptConfiguration : IEntityTypeConfiguration<AssessmentAttempt>
{
    public void Configure(EntityTypeBuilder<AssessmentAttempt> builder)
    {
        builder.ToTable("ncp_assessment_attempt");
        builder.HasKey(aa => aa.Id);

        builder.Property(aa => aa.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(aa => aa.AssessmentId)
               .HasColumnName("assessment_id")
               .IsRequired();

        builder.Property(aa => aa.StartedAt)
               .HasColumnName("started_at")
               .IsRequired();

        builder.Property(aa => aa.FinishedAt)
               .HasColumnName("finished_at")
               .IsRequired();

        builder.Property(aa => aa.UserLearningContextId)
               .HasColumnName("user_learning_context_id")
               .IsRequired();

        builder.Property(aa => aa.Score)
               .HasColumnName("score")
               .IsRequired();

        builder.Property(aa => aa.TotalQuestions)
               .HasColumnName("total_questions")
               .IsRequired();

        builder.Property(aa => aa.CorrectAnswers)
               .HasColumnName("correct_answers")
               .IsRequired();

        builder.HasOne(aa => aa.Assessment)
               .WithMany()
               .HasForeignKey(aa => aa.AssessmentId)
               .HasConstraintName("fk_assessment_attempt_assessment")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(aa => aa.AssessmentAttemptQuestions)
               .WithOne(aq => aq.AssessmentAttempt)
               .HasForeignKey(aq => aq.AssessmentAttemptId)
               .HasConstraintName("fk_assessment_attempt_question_assessment_attempt")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(aa => aa.UserLearningContext)
               .WithMany(ulc => ulc.AssessmentAttempts)
               .HasForeignKey(aa => aa.UserLearningContextId)
               .HasConstraintName("fk_assessment_attempt_user_learning_context")
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(aa => aa.StarsEarned)
               .HasColumnName("stars_earned")
               .IsRequired()
               .HasDefaultValue(0);
    }
}