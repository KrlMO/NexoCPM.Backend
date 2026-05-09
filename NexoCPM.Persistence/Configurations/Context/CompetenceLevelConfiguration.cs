using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Context.Entities;

namespace NexoCPM.Persistence.Configurations.Context;

public class CompetenceLevelConfiguration : IEntityTypeConfiguration<CompetenceLevel>
{
    public void Configure(EntityTypeBuilder<CompetenceLevel> builder)
    {
        builder.ToTable("ncp_competence_level");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(t => t.Code)
               .HasColumnName("code")
               .IsRequired()
               .HasMaxLength(20);

        builder.Property(t => t.LevelNumber)
               .HasColumnName("level_number")
               .IsRequired();

        builder.Property(t => t.Description)
               .HasColumnName("description")
               .HasMaxLength(500);

        builder.Property(t => t.CompetenceId)
               .HasColumnName("competence_id")
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

        builder.HasOne(t => t.Competence)
               .WithMany(c => c.CompetenceLevels)
               .HasForeignKey(t => t.CompetenceId)
               .HasConstraintName("fk_competence_level_competence")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(cl => cl.SubTopics)
            .WithOne(st => st.CompetenceLevel)
            .HasForeignKey(cl => cl.CompetenceLevelId)
            .HasConstraintName("fk_competence_level_subtopic")
            .OnDelete(DeleteBehavior.Cascade);
    }
}