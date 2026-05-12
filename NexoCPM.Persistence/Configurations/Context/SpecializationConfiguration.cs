using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Context.Entities;

namespace NexoCPM.Persistence.Configurations.Context;

public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
{
    public void Configure(EntityTypeBuilder<Specialization> builder)
    {
        builder.ToTable("ncp_specialization");
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(s => s.Code)
               .HasColumnName("code")
               .IsRequired()
               .HasMaxLength(50);

        builder.HasIndex(m => m.Code)
                .IsUnique(true);

        builder.Property(s => s.Name)
               .HasColumnName("name")
               .IsRequired();

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
               .IsRequired(true)
               .HasDefaultValue(1);

        builder.Property(t => t.UpdatedBy)
                .HasColumnName("updated_by")
                .IsRequired(false)
               .HasDefaultValue(1);

        builder.Property(t => t.DeletedBy)
               .HasColumnName("deleted_by")
               .IsRequired(false);

        builder.HasMany(s => s.EducationContexts)
               .WithOne(c => c.Specialization)
               .HasForeignKey(c => c.SpecializationId)
               .HasConstraintName("fk_education_context_specialization")
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(s => s.Slug)
            .HasColumnName("slug")
            .HasMaxLength(100)
            .IsRequired(true);

        builder.HasIndex(s => s.Slug)
            .IsUnique(true);

        builder.Property(s => s.Description)
            .IsRequired(false);
    }
}