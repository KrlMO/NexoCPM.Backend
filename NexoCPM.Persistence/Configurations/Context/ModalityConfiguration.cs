using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Context.Entities;

namespace NexoCPM.Persistence.Configurations.Context;

public class ModalityConfiguration : IEntityTypeConfiguration<Modality>
{
    public void Configure(EntityTypeBuilder<Modality> builder)
    {
        builder.ToTable("ncp_modality");
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(m => m.Code)
               .HasColumnName("code")
               .IsRequired()
               .HasMaxLength(50);

        builder.HasIndex(m => m.Code)
                .IsUnique(true);

        builder.Property(m => m.Name)
               .HasColumnName("name")
               .IsRequired(true);

        builder.Property(m => m.IsActive)
               .HasColumnName("is_active")
               .HasDefaultValue(true);

        builder.Property(m => m.IsDeleted)
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
               .IsRequired(true)
               .HasDefaultValue(1);

        builder.Property(t => t.UpdatedBy)
                .HasColumnName("updated_by")
                .IsRequired(false)
               .HasDefaultValue(1);

        builder.Property(t => t.DeletedBy)
               .HasColumnName("deleted_by")
               .IsRequired(false);

        builder.HasMany(m => m.Levels)
               .WithOne(l => l.Modality)
               .HasForeignKey(l => l.ModalityId)
               .HasConstraintName("fk_level_modality")
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(m => m.Slug)
            .HasColumnName("slug")
            .HasMaxLength(100)
            .IsRequired(true);

        builder.HasIndex(m => m.Slug)
            .IsUnique(true);
    }
}