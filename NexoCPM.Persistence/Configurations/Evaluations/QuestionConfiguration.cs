using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Evaluations.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Evaluations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("ncp_question");
            builder.HasKey(q => q.Id);

            builder.Property(q => q.Statement)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(q => q.Explanation)
                   .HasMaxLength(1000);

            builder.Property(q => q.IsActive)
                   .IsRequired();

            builder.Property(q => q.Difficulty)
                   .IsRequired();

            builder.HasOne(q => q.Topic)
                   .WithMany(t => t.Questions)
                   .HasForeignKey(q => q.TopicId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
