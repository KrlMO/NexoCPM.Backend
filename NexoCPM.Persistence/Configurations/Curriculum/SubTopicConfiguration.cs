using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Curriculum.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Curriculum
{
    public class SubTopicConfiguration : IEntityTypeConfiguration<SubTopic>
    {
        public void Configure(EntityTypeBuilder<SubTopic> builder)
        {
            builder.ToTable("ncp_sub_topic");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Code)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(t => t.OrderIndex).IsRequired();
            builder.Property(t => t.IsActive).IsRequired();

            builder.HasOne(t => t.Topic)
                   .WithMany()
                   .HasForeignKey(t => t.TopicId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t => t.MicroTopics)
                   .WithOne(st => st.SubTopic)
                   .HasForeignKey(st => st.SubTopicId)
                   .OnDelete(DeleteBehavior.Cascade);

             builder.HasMany(t => t.Questions)
                   .WithOne(qt => qt.SubTopic)
                   .HasForeignKey(qt => qt.SubTopicId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(st => st.Resources)
                   .WithOne(r => r.SubTopic)
                   .HasForeignKey(r => r.SubTopicId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
