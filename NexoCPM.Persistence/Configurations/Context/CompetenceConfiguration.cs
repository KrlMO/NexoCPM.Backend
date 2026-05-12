using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Context.Entities;

namespace NexoCPM.Persistence.Configurations.Context;

public class CompetenceConfiguration : IEntityTypeConfiguration<Competence>
{
    public void Configure(EntityTypeBuilder<Competence> builder)
    {
        builder.ToTable("ncp_competence");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(t => t.Code)
               .HasColumnName("code")
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(t => t.Name)
               .HasColumnName("name")
               .IsRequired()
                .HasMaxLength(255);

        builder.Property(t => t.Description)
               .HasColumnName("description");

        builder.Property(t => t.EffectYear)
               .HasColumnName("effect_year")
               .IsRequired();

        builder.Property(t => t.IsActive)
               .HasColumnName("is_active")
               .IsRequired()
               .HasDefaultValue(true);

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

        builder.HasMany(t => t.CompetenceLevels)
                .WithOne(cl => cl.Competence)
                .HasForeignKey(cl => cl.CompetenceId)
                .HasConstraintName("fk_competence_level_competence")
                .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.SubTopics)
            .WithOne(st => st.Competence)
            .HasForeignKey(c => c.CompetenceId).HasConstraintName("fk_subtopic_competence")
            .OnDelete(DeleteBehavior.NoAction);
    }
}