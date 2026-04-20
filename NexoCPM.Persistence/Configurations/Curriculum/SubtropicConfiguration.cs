using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Curriculum.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Curriculum
{
    public class SubtopicConfiguration : IEntityTypeConfiguration<Subtopic>
    {
        public void Configure(EntityTypeBuilder<Subtopic> builder)
        {
            builder.ToTable("ncp_subtopic");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Code).HasMaxLength(20).IsRequired();
            builder.Property(s => s.OrderIndex).IsRequired();
            builder.HasOne(s => s.Topic)
                   .WithMany(t => t.Subtopics)
                   .HasForeignKey(s => s.TopicId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
