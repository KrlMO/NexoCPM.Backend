using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Context.Entities;

namespace NexoCPM.Persistence.Configurations.Context
{
    public class CompetenceLevelUnitConfiguration : IEntityTypeConfiguration<CompetenceLevelUnit>
    {
        public void Configure(EntityTypeBuilder<CompetenceLevelUnit> builder)
        {
            builder.ToTable("ncp_competence_level_unit");
            builder.HasKey(t => new { t.CompetenceLevelId, t.SyllabusUnitId });

            builder.HasOne(t => t.CompetenceLevel)
                   .WithMany(c => c.CompetenceLevelUnits)
                   .HasForeignKey(t => t.CompetenceLevelId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(t => t.SyllabusUnit)
                   .WithMany()
                   .HasForeignKey(t => t.SyllabusUnitId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}