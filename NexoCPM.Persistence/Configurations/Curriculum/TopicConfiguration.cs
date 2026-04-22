using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Curriculum.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Curriculum
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.ToTable("ncp_topic");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Code)
                   .IsRequired()
                   .HasMaxLength(20);
            builder.Property(t => t.Name)
                   .IsRequired();
            builder.Property(t => t.IsDeleted).IsRequired();
            builder.Property(t => t.IsActive).IsRequired();

builder.HasOne(st => st.SyllabusUnit)
                 .WithMany(su => su.Topics)
                 .HasForeignKey(st => st.SyllabusUnitId)
                 .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(st => st.SubTopics)
                .WithOne(t => t.Topic)
                .HasForeignKey(t => t.TopicId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
