using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Curriculum.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Curriculum
{
    public class SyllabusContextConfiguration : IEntityTypeConfiguration<SyllabusContext>
    {
        public void Configure(EntityTypeBuilder<SyllabusContext> builder)
        {
            builder.ToTable("ncp_syllabus_context");
            builder.HasKey(sc => new { sc.SyllabusId, sc.EducationContextId});

            builder.HasOne(sc => sc.Syllabus)
                   .WithMany(s => s.SyllabusContexts)
                   .HasForeignKey(sc => sc.SyllabusId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(sc => sc.EducationContext)
                    .WithMany(ec => ec.SyllabusContexts)
                    .HasForeignKey(sc => sc.EducationContextId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
