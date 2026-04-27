using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Evaluations.Entities;

namespace NexoCPM.Persistence.Configurations.Evaluations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable("ncp_question");
        builder.HasKey(q => q.Id);

        builder.Property(q => q.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(q => q.Code)
               .HasColumnName("code")
               .IsRequired()
               .HasMaxLength(20);

        builder.Property(q => q.Explanation)
               .HasColumnName("explanation")
               .IsRequired(false);

        builder.Property(q => q.IsActive)
               .HasColumnName("is_active")
               .IsRequired()
               .HasDefaultValue(true);

        builder.Property(q => q.IsDeleted)
               .HasColumnName("is_deleted")
               .IsRequired()
               .HasDefaultValue(false);

        builder.Property(q => q.TotalAttempts)
               .HasColumnName("total_attempts")
               .IsRequired();

        builder.Property(q => q.TotalCorrect)
               .HasColumnName("total_correct")
               .IsRequired();

        builder.Property(q => q.SubTopicId)
               .HasColumnName("sub_topic_id")
               .IsRequired();

        builder.HasIndex(q => q.Code)
               .IsUnique();

        builder.Property(t => t.CreatedAt)
               .HasColumnName("created_at")
               .IsRequired()
               .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(t => t.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired(false);

        builder.Property(t => t.DeletedAt)
               .HasColumnName("deleted_at")
               .IsRequired(false);

        builder.Property(t => t.CreatedBy)
               .HasColumnName("created_by")
               .IsRequired(true);
        builder.Property(t => t.UpdatedBy)
                .HasColumnName("updated_by")
                .IsRequired(false);

        builder.Property(t => t.DeletedBy)
               .HasColumnName("deleted_by")
               .IsRequired(false);

        builder.HasMany(q => q.Options)
               .WithOne(o => o.Question)
               .HasForeignKey(o => o.QuestionId)
               .HasConstraintName("fk_option_question")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(q => q.AssessmentAttemptQuestions)
               .WithOne(aq => aq.Question)
               .HasForeignKey(aq => aq.QuestionId)
               .HasConstraintName("fk_assessment_attempt_question_question")
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(q => q.QuestionContentBlocks)
               .WithOne(qcq => qcq.Question)
               .HasForeignKey(qcq => qcq.QuestionId)
               .HasConstraintName("fk_question_content_block_question")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(q => q.SubTopic)
               .WithMany(st => st.Questions)
               .HasForeignKey(q => q.SubTopicId)
               .HasConstraintName("fk_question_sub_topic")
               .OnDelete(DeleteBehavior.Restrict);
    }
}