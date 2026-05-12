using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Context.Entities;

namespace NexoCPM.Persistence.Configurations.Context;

public class AbilityConfiguration : IEntityTypeConfiguration<Ability>
{
    public void Configure(EntityTypeBuilder<Ability> builder)
    {
        builder.ToTable("ncp_ability");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(t => t.Name)
               .HasColumnName("name")
               .IsRequired()
                .HasMaxLength(255);

        builder.Property(t => t.Code)
               .HasColumnName("code")
               .IsRequired(true)
               .HasMaxLength(50);

        builder.HasIndex(t => t.Code)
            .IsUnique();

        builder.Property(t => t.Description)
               .HasColumnName("description");

        builder.Property(t => t.CompetenceId)
               .HasColumnName("competence_id")
               .IsRequired();

        builder.HasOne(t => t.Competence)
               .WithMany(c => c.Abilities)
               .HasForeignKey(t => t.CompetenceId)
               .HasConstraintName("fk_ability_competence")
               .OnDelete(DeleteBehavior.Cascade);

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
    }
}
