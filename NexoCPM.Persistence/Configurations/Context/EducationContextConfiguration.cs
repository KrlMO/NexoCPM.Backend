using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Context
{
    public class EducationContextConfiguration : IEntityTypeConfiguration<EducationContext>
    {
        public void Configure(EntityTypeBuilder<EducationContext> builder)
        {
            builder.ToTable("ncp_education_context");

            builder.HasKey(ec => ec.Id);

            builder.HasIndex(ec => new { ec.LevelId, ec.SpecializationId })
                   .IsUnique();

            builder.HasOne(ec => ec.Level)
               .WithMany()
               .HasForeignKey(ec => ec.LevelId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(ec => ec.Specialization)
                   .WithMany()
                   .HasForeignKey(ec => ec.SpecializationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(ec => ec.SyllabusContexts)
                   .WithOne(sc => sc.EducationContext)
                   .HasForeignKey(sc => sc.EducationContextId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
