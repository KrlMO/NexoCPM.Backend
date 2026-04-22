using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Curriculum.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Curriculum
{
    public class MicroTopicConfiguration : IEntityTypeConfiguration<MicroTopic>
    {
        public void Configure(EntityTypeBuilder<MicroTopic> builder)
        {
            builder.ToTable("ncp_micro_topic");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Code).HasMaxLength(20).IsRequired();
            builder.Property(s => s.OrderIndex).IsRequired();
            builder.HasOne(s => s.SubTopic)
                   .WithMany(t => t.MicroTopics)
                   .HasForeignKey(s => s.SubTopicId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
