using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Curriculum.Entities;

namespace NexoCPM.Persistence.Configurations.Curriculum;

public class SyllabusContextConfiguration : IEntityTypeConfiguration<SyllabusContext>
{
    public void Configure(EntityTypeBuilder<SyllabusContext> builder)
    {
        builder.ToTable("ncp_syllabus_context");
        builder.HasKey(sc => new { sc.SyllabusId, sc.EducationContextId });

        builder.Property(sc => sc.SyllabusId)
               .HasColumnName("syllabus_id")
               .IsRequired();

        builder.Property(sc => sc.EducationContextId)
               .HasColumnName("education_context_id")
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

        builder.HasOne(sc => sc.Syllabus)
               .WithMany(s => s.SyllabusContexts)
               .HasForeignKey(sc => sc.SyllabusId)
               .HasConstraintName("fk_syllabus_context_syllabus")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(sc => sc.EducationContext)
               .WithMany(ec => ec.SyllabusContexts)
               .HasForeignKey(sc => sc.EducationContextId)
               .HasConstraintName("fk_syllabus_context_education_context")
               .OnDelete(DeleteBehavior.Cascade);
    }
}