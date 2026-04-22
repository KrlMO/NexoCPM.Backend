using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Context
{
    public class CompetenceConfiguration : IEntityTypeConfiguration<Competence>
    {
public void Configure(EntityTypeBuilder<Competence> builder)
        {
            builder.ToTable("ncp_competence");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Code)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(t => t.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(t => t.Description)
                   .HasMaxLength(500);

            builder.Property(t => t.EffectYear)
                   .IsRequired();

            builder.Property(t => t.IsActive)
                   .IsRequired();
        }
    }
}
