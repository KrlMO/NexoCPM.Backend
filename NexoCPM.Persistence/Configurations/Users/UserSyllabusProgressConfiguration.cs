using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Users.Entities;

namespace NexoCPM.Persistence.Configurations.Users;

public class UserSyllabusProgressConfiguration : IEntityTypeConfiguration<UserSyllabusProgress>
{
    public void Configure(EntityTypeBuilder<UserSyllabusProgress> builder)
    {
        builder.ToTable("ncp_user_syllabus_progress");
        builder.HasKey(usp => usp.Id);

        builder.Property(usp => usp.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(usp => usp.UserLearningContextId)
               .HasColumnName("user_learning_context_id")
               .IsRequired();

        builder.Property(usp => usp.UserId)
               .HasColumnName("user_id")
               .IsRequired();

        builder.Property(usp => usp.SyllabusId)
               .HasColumnName("syllabus_id")
               .IsRequired();

        builder.Property(usp => usp.CompletedUnits)
               .HasColumnName("completed_units")
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(usp => usp.TotalUnits)
               .HasColumnName("total_units")
               .IsRequired()
               .HasDefaultValue(0);

        builder.Property(usp => usp.ContentProgressPercentage)
               .HasColumnName("content_progress_percentage")
               .IsRequired()
               .HasDefaultValue(0.0);

        builder.Property(usp => usp.FinalExamCompleted)
               .HasColumnName("final_exam_completed")
               .IsRequired()
               .HasDefaultValue(false);

        builder.Property(usp => usp.FinalExamScore)
               .HasColumnName("final_exam_score");

        builder.Property(usp => usp.OverallProgressPercentage)
               .HasColumnName("overall_progress_percentage")
               .IsRequired()
               .HasDefaultValue(0.0);

        builder.Property(usp => usp.CompletedAt)
               .HasColumnName("completed_at");

        builder.Property(usp => usp.LastAccess)
               .HasColumnName("last_access")
               .IsRequired();

        builder.Property(usp => usp.LastActivityAt)
               .HasColumnName("last_activity_at")
               .IsRequired();

        builder.Property(usp => usp.Status)
               .HasColumnName("status")
               .HasConversion<int>()
               .IsRequired();

        builder.HasIndex(usp => usp.UserLearningContextId)
               .IsUnique(true);

        builder.HasOne(usp => usp.UserLearningContext)
               .WithOne(ulc => ulc.UserSyllabusProgress)
               .HasForeignKey<UserSyllabusProgress>(usp => usp.UserLearningContextId)
               .HasConstraintName("fk_user_syllabus_progress_user_learning_context")
               .OnDelete(DeleteBehavior.NoAction);

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
               .IsRequired(true)
               .HasDefaultValue(1);

        builder.Property(t => t.UpdatedBy)
                .HasColumnName("updated_by")
                .IsRequired(false)
               .HasDefaultValue(1);

        builder.Property(t => t.DeletedBy)
               .HasColumnName("deleted_by")
               .IsRequired(false);
    }
}
