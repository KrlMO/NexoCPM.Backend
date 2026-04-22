using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Curriculum.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Curriculum
{
    public class SyllabusUnitConfiguration : IEntityTypeConfiguration<SyllabusUnit>
    {
        public void Configure(EntityTypeBuilder<SyllabusUnit> builder)
        {
            builder.ToTable("ncp_syllabus_unit");

            builder.HasKey(su => su.Id);

            builder.Property(su => su.Code)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property<string>(su => su.Name).IsRequired();

            builder.Property(su => su.OrderIndex).IsRequired();

            builder.HasOne(su => su.Syllabus)
                   .WithMany(s => s.SyllabusUnits)
                   .HasForeignKey(su => su.SyllabusId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(su => su.UserSyllabusUnitProgresses)
                   .WithOne(usp => usp.SyllabusUnit)
                   .HasForeignKey(usp => usp.SyllabusUnitId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(su => su.CompetenceLevelUnits)
                   .WithOne(clu => clu.SyllabusUnit)
                   .HasForeignKey(clu => clu.SyllabusUnitId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
