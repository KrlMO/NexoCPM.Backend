using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Context.Entities;

namespace NexoCPM.Persistence.Configurations.Context
{
    public class CompetenceLevelConfiguration : IEntityTypeConfiguration<CompetenceLevel>
    {
        public void Configure(EntityTypeBuilder<CompetenceLevel> builder)
        {
            builder.ToTable("ncp_competence_level");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Code)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(t => t.LevelNumber)
                   .IsRequired();

            builder.Property(t => t.Description)
                   .HasMaxLength(500);

            builder.HasOne(t => t.Competence)
                   .WithMany(c => c.CompetenceLevels)
                   .HasForeignKey(t => t.CompetenceId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}