using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Context.Entities;

namespace NexoCPM.Persistence.Configurations.Context;

public class LevelConfiguration : IEntityTypeConfiguration<Level>
{
    public void Configure(EntityTypeBuilder<Level> builder)
    {
        builder.ToTable("ncp_level");
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(l => l.Code)
               .HasColumnName("code")
               .IsRequired()
               .HasMaxLength(50);

        builder.HasIndex(l => l.Code)
                .IsUnique(true);

        builder.Property(l => l.Name)
               .HasColumnName("name")
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(l => l.ModalityId)
               .HasColumnName("modality_id")
               .IsRequired();

        builder.Property(l => l.IsActive)
               .HasColumnName("is_active")
               .HasDefaultValue(true);

        builder.Property(l => l.IsDeleted)
               .HasColumnName("is_deleted")
               .HasDefaultValue(false);

        builder.Property(l => l.CreatedAt)
               .HasColumnName("created_at")
               .IsRequired()
               .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(l => l.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired(false)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(l => l.DeletedAt)
               .HasColumnName("deleted_at")
               .IsRequired(false);

        builder.Property(l => l.CreatedBy)
               .HasColumnName("created_by")
               .IsRequired(true)
               .HasDefaultValue(1);

        builder.Property(l => l.UpdatedBy)
                .HasColumnName("updated_by")
                .IsRequired(false)
               .HasDefaultValue(1);

        builder.Property(l => l.DeletedBy)
               .HasColumnName("deleted_by")
               .IsRequired(false);

        builder.HasOne(l => l.Modality)
               .WithMany(m => m.Levels)
               .HasForeignKey(l => l.ModalityId)
               .HasConstraintName("fk_level_modality")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(l => l.EducationContexts)
               .WithOne(c => c.Level)
               .HasForeignKey(c => c.LevelId)
               .HasConstraintName("fk_education_context_level")
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(l => l.Slug)
            .HasColumnName("slug")
            .HasMaxLength(100)
            .IsRequired(true);

        builder.HasIndex(l => l.Slug)
            .IsUnique(true);
    }
}