using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Evaluations.Entities;

namespace NexoCPM.Persistence.Configurations.Evaluations;

public class AssessmentAttemptQuestionConfiguration : IEntityTypeConfiguration<AssessmentAttemptQuestion>
{
    public void Configure(EntityTypeBuilder<AssessmentAttemptQuestion> builder)
    {
        builder.ToTable("ncp_assessment_attempt_question");
        builder.HasKey(aaq => aaq.Id);

        builder.Property(aaq => aaq.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(aaq => aaq.AssessmentAttemptId)
               .HasColumnName("assessment_attempt_id")
               .IsRequired();

        builder.Property(aaq => aaq.QuestionId)
               .HasColumnName("question_id")
               .IsRequired();

        builder.Property(aaq => aaq.SelectedOptionId)
               .HasColumnName("selected_option_id")
               .IsRequired(false);

        builder.Property(aaq => aaq.AnsweredAt)
               .HasColumnName("answered_at")
               .IsRequired();

        builder.Property(aaq => aaq.SecondsSpent)
               .HasColumnName("seconds_spent")
               .IsRequired();

        builder.Property(aaq => aaq.OrderIndex)
               .HasColumnName("order_index")
               .IsRequired();

        builder.HasIndex(aaq => new { aaq.AssessmentAttemptId, aaq.QuestionId })
               .IsUnique();

        builder.HasOne(aaq => aaq.AssessmentAttempt)
               .WithMany(aa => aa.AssessmentAttemptQuestions)
               .HasForeignKey(aaq => aaq.AssessmentAttemptId)
               .HasConstraintName("fk_assessment_attempt_question_assessment_attempt")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(aaq => aaq.Question)
               .WithMany(q => q.AssessmentAttemptQuestions)
               .HasForeignKey(aaq => aaq.QuestionId)
               .HasConstraintName("fk_assessment_attempt_question_question")
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(aaq => aaq.SelectedOption)
               .WithMany(so => so.AssessmentAttemptQuestions)
               .HasForeignKey(aaq => aaq.SelectedOptionId)
               .HasConstraintName("fk_assessment_attempt_question_selected_option")
               .OnDelete(DeleteBehavior.SetNull);
    }
}