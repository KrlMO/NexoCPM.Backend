using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Context
{
    public class ModalityConfiguration : IEntityTypeConfiguration<Modality>
    {
        public void Configure(EntityTypeBuilder<Modality> builder)
        {
            builder.ToTable("ncp_modality");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Code)
                   .IsRequired()
                   .HasMaxLength(20);
            builder.Property(m => m.Name)
                   .IsRequired();

            builder.HasMany(m => m.Levels)
                   .WithOne(l => l.Modality)
                   .HasForeignKey(l => l.ModalityId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
