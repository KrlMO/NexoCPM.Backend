using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Users.Entities;

namespace NexoCPM.Persistence.Configurations.Users;

public class UserSyllabusUnitProgressConfiguration : IEntityTypeConfiguration<UserSyllabusUnitProgress>
{
    public void Configure(EntityTypeBuilder<UserSyllabusUnitProgress> builder)
    {
        builder.ToTable("ncp_user_syllabus_unit_progress");
        builder.HasKey(usup => usup.Id);

        builder.Property(usup => usup.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(usup => usup.UserSyllabusProgressId)
               .HasColumnName("user_syllabus_progress_id")
               .IsRequired();

        builder.Property(usup => usup.SyllabusUnitId)
               .HasColumnName("syllabus_unit_id")
               .IsRequired();

        builder.Property(usup => usup.Status)
               .HasColumnName("status")
               .HasConversion<int>()
               .IsRequired();

        builder.Property(usup => usup.Attempts)
               .HasColumnName("attempts")
               .IsRequired();

        builder.Property(usup => usup.LastAttemptAt)
               .HasColumnName("last_attempt_at")
               .IsRequired();

        builder.Property(usup => usup.TotalQuestions)
               .HasColumnName("total_questions")
               .IsRequired();

        builder.Property(usup => usup.TotalCorrect)
               .HasColumnName("total_correct")
               .IsRequired();

        builder.HasIndex(usup => new { usup.UserSyllabusProgressId, usup.SyllabusUnitId })
               .IsUnique(true);

        builder.HasOne(usup => usup.SyllabusUnit)
               .WithMany(su => su.UserSyllabusUnitProgresses)
               .HasForeignKey(usup => usup.SyllabusUnitId)
               .HasConstraintName("fk_user_syllabus_unit_progress_syllabus_unit")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(usup => usup.UserSyllabusProgress)
               .WithMany(usp => usp.UserSyllabusUnitProgresses)
               .HasForeignKey(usup => usup.UserSyllabusProgressId)
               .HasConstraintName("fk_user_syllabus_unit_progress_user_syllabus_progress")
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