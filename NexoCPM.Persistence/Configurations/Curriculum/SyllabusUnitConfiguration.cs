using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Curriculum.Entities;

namespace NexoCPM.Persistence.Configurations.Curriculum;

public class SyllabusUnitConfiguration : IEntityTypeConfiguration<SyllabusUnit>
{
    public void Configure(EntityTypeBuilder<SyllabusUnit> builder)
    {
        builder.ToTable("ncp_syllabus_unit");
        builder.HasKey(su => su.Id);

        builder.Property(su => su.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(su => su.Code)
               .HasColumnName("code")
               .IsRequired(true)
               .HasMaxLength(50);

        builder.HasIndex(su => su.Code)
            .IsUnique();

        builder.Property(su => su.Name)
               .HasColumnName("name")
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(su => su.OrderIndex)
               .HasColumnName("order_index")
               .IsRequired();

        builder.Property(su => su.SyllabusId)
               .HasColumnName("syllabus_id")
               .IsRequired();

        builder.Property(su => su.IsActive)
               .HasColumnName("is_active")
               .HasDefaultValue(true);

        builder.Property(su => su.IsDeleted)
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

        builder.HasOne(su => su.Syllabus)
               .WithMany(s => s.SyllabusUnits)
               .HasForeignKey(su => su.SyllabusId)
               .HasConstraintName("fk_syllabus_unit_syllabus")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(su => su.UserSyllabusUnitProgresses)
               .WithOne(usp => usp.SyllabusUnit)
               .HasForeignKey(usp => usp.SyllabusUnitId)
               .HasConstraintName("fk_user_syllabus_unit_progress_syllabus_unit")
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(su => su.Slug)
            .HasColumnName("slug")
            .HasMaxLength(100)
            .IsRequired(true);

        builder.HasIndex(su => su.Slug)
            .IsUnique();

        builder.Property(su => su.Description)
            .HasColumnName("description")
            .HasMaxLength(200)
            .IsRequired(false);
    }
}