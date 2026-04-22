using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Context
{
    public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
    {
        public void Configure(EntityTypeBuilder<Specialization> builder)
        {
            builder.ToTable("ncp_specialization");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Code)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.HasMany(s => s.EducationContexts)
                   .WithOne(c => c.Specialization)
                   .HasForeignKey(c => c.SpecializationId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
