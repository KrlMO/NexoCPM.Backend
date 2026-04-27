using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Curriculum.Entities;

namespace NexoCPM.Persistence.Configurations.Curriculum;

public class SyllabusConfiguration : IEntityTypeConfiguration<Syllabus>
{
    public void Configure(EntityTypeBuilder<Syllabus> builder)
    {
        builder.ToTable("ncp_syllabus");
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(s => s.Name)
               .HasColumnName("name")
               .IsRequired();

        builder.Property(s => s.Code)
               .HasColumnName("code")
               .IsRequired()
               .HasMaxLength(20);

        builder.Property(s => s.IsActive)
               .HasColumnName("is_active")
               .HasDefaultValue(true);

        builder.Property(s => s.IsDeleted)
               .HasColumnName("is_deleted")
               .HasDefaultValue(false);

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

        builder.HasMany(s => s.UserLearningContexts)
               .WithOne(usp => usp.Syllabus)
               .HasForeignKey(usp => usp.SyllabusId)
               .HasConstraintName("fk_user_learning_context_syllabus")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(s => s.SyllabusContexts)
               .WithOne(sc => sc.Syllabus)
               .HasForeignKey(sc => sc.SyllabusId)
               .HasConstraintName("fk_syllabus_context_syllabus")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(s => s.SyllabusUnits)
               .WithOne(sc => sc.Syllabus)
               .HasForeignKey(sc => sc.SyllabusId)
               .HasConstraintName("fk_syllabus_unit_syllabus")
               .OnDelete(DeleteBehavior.Cascade);
    }
}