using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Evaluations.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Evaluations
{
    public class QuestionSubtopicConfiguration : IEntityTypeConfiguration<QuestionSubTopic>
    {
        public void Configure(EntityTypeBuilder<QuestionSubTopic> builder)
        {
            builder.ToTable("ncp_question_subtopic");
            builder.HasKey(qs => new { qs.QuestionId, qs.SubTopicId });

            builder.HasOne(qs => qs.Question)
                   .WithMany(q => q.QuestionSubTopics)
                   .HasForeignKey(qs => qs.QuestionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(qs => qs.Subtopic)
                   .WithMany(s => s.QuestionSubTopics)
                   .HasForeignKey(qs => qs.SubTopicId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}