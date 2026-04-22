using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Curriculum.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Curriculum
{
    public class SyllabusConfiguration : IEntityTypeConfiguration<Syllabus>
    {
        public void Configure(EntityTypeBuilder<Syllabus> builder)
        {
            builder.ToTable("ncp_syllabus");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                   .IsRequired();
            builder.Property(s => s.Code)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.HasMany(s => s.UserLearningContexts)
                .WithOne(usp => usp.Syllabus)
                .HasForeignKey(usp => usp.SyllabusId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.SyllabusContexts)
                .WithOne(sc => sc.Syllabus)
                .HasForeignKey(sc => sc.SyllabusId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(s => s.SyllabusUnits)
                .WithOne(sc => sc.Syllabus)
                .HasForeignKey(sc => sc.SyllabusId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
