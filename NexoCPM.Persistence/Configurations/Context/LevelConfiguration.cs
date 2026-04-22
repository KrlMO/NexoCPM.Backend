using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Context
{
    public class LevelConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.ToTable("ncp_level");
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Code)
                   .IsRequired()
                   .HasMaxLength(20);
            builder.Property(l => l.Name)
                                   .IsRequired();

            builder.HasOne(l => l.Modality) 
                   .WithMany(m => m.Levels) 
                   .HasForeignKey(l => l.ModalityId) 
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(l => l.EducationContexts) 
                   .WithOne(c => c.Level) 
                   .HasForeignKey(c => c.LevelId) 
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
