using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Evaluations.Entities;

namespace NexoCPM.Persistence.Configurations.Evaluations;

public class AssessmentConfiguration : IEntityTypeConfiguration<Assessment>
{
    public void Configure(EntityTypeBuilder<Assessment> builder)
    {
        builder.ToTable("ncp_assessment");
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(a => a.Code)
               .HasColumnName("code")
               .IsRequired()
               .HasMaxLength(50);

        builder.HasIndex(a => a.Code)
            .IsUnique();

        builder.Property(a => a.Title)
               .HasColumnName("title")
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(a => a.Type)
               .HasColumnName("type")
               .IsRequired()
               .HasConversion<int>();

        builder.Property(a => a.Scope)
               .HasColumnName("scope")
               .IsRequired()
               .HasConversion<int>();

        builder.Property(a => a.TargetId)
               .HasColumnName("target_id")
               .IsRequired(false);

        builder.Property(a => a.IsActive)
               .HasColumnName("is_active")
               .IsRequired()
               .HasDefaultValue(true);

        builder.Property(a => a.TimeLimitSeconds)
               .HasColumnName("time_limit_seconds")
               .IsRequired(false);

        builder.Property(a => a.NumberQuestions)
               .HasColumnName("number_questions")
               .IsRequired();

        builder.Property(a => a.MaxAttempts)
               .HasColumnName("max_attempts")
               .IsRequired(false);

        builder.HasIndex(a => a.Code).IsUnique(true);

        builder.HasMany(a => a.AssessmentAttempts)
               .WithOne(aa => aa.Assessment)
               .HasForeignKey(aa => aa.AssessmentId)
               .HasConstraintName("fk_assessment_attempt_assessment")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(a => new { a.Scope, a.TargetId });
    }
}