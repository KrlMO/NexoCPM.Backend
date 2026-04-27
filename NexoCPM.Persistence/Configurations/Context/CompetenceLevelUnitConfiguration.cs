using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Context.Entities;

namespace NexoCPM.Persistence.Configurations.Context;

public class CompetenceLevelUnitConfiguration : IEntityTypeConfiguration<CompetenceLevelUnit>
{
    public void Configure(EntityTypeBuilder<CompetenceLevelUnit> builder)
    {
        builder.ToTable("ncp_competence_level_unit");
        builder.HasKey(t => new { t.CompetenceLevelId, t.SyllabusUnitId });

        builder.Property(t => t.CompetenceLevelId)
               .HasColumnName("competence_level_id")
               .IsRequired();

        builder.Property(t => t.SyllabusUnitId)
               .HasColumnName("syllabus_unit_id")
               .IsRequired();

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

        builder.HasOne(t => t.CompetenceLevel)
               .WithMany(c => c.CompetenceLevelUnits)
               .HasForeignKey(t => t.CompetenceLevelId)
               .HasConstraintName("fk_competence_level_unit_competence_level")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(t => t.SyllabusUnit)
               .WithMany()
               .HasForeignKey(t => t.SyllabusUnitId)
               .HasConstraintName("fk_competence_level_unit_syllabus_unit")
               .OnDelete(DeleteBehavior.Cascade);
    }
}