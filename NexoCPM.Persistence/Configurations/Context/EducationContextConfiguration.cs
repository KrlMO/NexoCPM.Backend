using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Context.Entities;

namespace NexoCPM.Persistence.Configurations.Context;

public class EducationContextConfiguration : IEntityTypeConfiguration<EducationContext>
{
    public void Configure(EntityTypeBuilder<EducationContext> builder)
    {
        builder.ToTable("ncp_education_context");
        builder.HasKey(ec => ec.Id);

        builder.Property(ec => ec.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(ec => ec.LevelId)
               .HasColumnName("level_id")
               .IsRequired();

        builder.Property(ec => ec.SpecializationId)
               .HasColumnName("specialization_id")
               .IsRequired();

        builder.Property(ec => ec.IsActive)
               .HasColumnName("is_active")
               .HasDefaultValue(true);

        builder.Property(ec => ec.IsDeleted)
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

        builder.HasIndex(ec => new { ec.LevelId, ec.SpecializationId })
               .IsUnique();

        builder.HasOne(ec => ec.Level)
               .WithMany()
               .HasForeignKey(ec => ec.LevelId)
               .HasConstraintName("fk_education_context_level")
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ec => ec.Specialization)
               .WithMany()
               .HasForeignKey(ec => ec.SpecializationId)
               .HasConstraintName("fk_education_context_specialization")
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(ec => ec.SyllabusContexts)
               .WithOne(sc => sc.EducationContext)
               .HasForeignKey(sc => sc.EducationContextId)
               .HasConstraintName("fk_syllabus_context_education_context")
               .OnDelete(DeleteBehavior.Cascade);
    }
}