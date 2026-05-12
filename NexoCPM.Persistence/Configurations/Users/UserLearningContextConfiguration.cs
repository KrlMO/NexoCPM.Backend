using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Users.Entities;

namespace NexoCPM.Persistence.Configurations.Users;

public class UserLearningContextConfiguration : IEntityTypeConfiguration<UserLearningContext>
{
    public void Configure(EntityTypeBuilder<UserLearningContext> builder)
    {
        builder.ToTable("ncp_user_learning_context");
        builder.HasKey(ulc => ulc.Id);

        builder.Property(ulc => ulc.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(ulc => ulc.UserId)
               .HasColumnName("user_id")
               .IsRequired();

        builder.Property(ulc => ulc.SyllabusId)
               .HasColumnName("syllabus_id")
               .IsRequired();

        builder.Property(ulc => ulc.IsActive)
               .HasColumnName("is_active")
               .HasDefaultValue(true);

        builder.Property(ulc => ulc.IsDeleted)
               .HasColumnName("is_deleted")
               .HasDefaultValue(false);

        builder.HasOne(ulc => ulc.UserSyllabusProgress)
               .WithOne(usp => usp.UserLearningContext)
               .HasForeignKey<UserSyllabusProgress>(usp => usp.UserLearningContextId)
               .HasConstraintName("fk_user_syllabus_progress_user_learning_context")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ulc => ulc.User)
               .WithMany(u => u.UserLearningContexts)
               .HasForeignKey(ulc => ulc.UserId)
               .HasConstraintName("fk_user_learning_context_user")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ulc => ulc.Syllabus)
               .WithMany(s => s.UserLearningContexts)
               .HasForeignKey(ulc => ulc.SyllabusId)
               .HasConstraintName("fk_user_learning_context_syllabus")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(ulc => ulc.AssessmentAttempts)
               .WithOne(usup => usup.UserLearningContext)
               .HasForeignKey(usup => usup.UserLearningContextId)
               .HasConstraintName("fk_assessment_attempt_user_learning_context")
               .OnDelete(DeleteBehavior.Cascade);

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