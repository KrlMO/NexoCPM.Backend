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

            builder.Property(q => q.Code)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.HasIndex(q => q.Code)
                   .IsUnique();

            builder.Property(q => q.Explanation)
                   .IsRequired(false);

            builder.Property(q => q.IsActive)
                   .IsRequired();

            builder.Property(q => q.IsDeleted)
                   .IsRequired();

            builder.Property(q => q.TotalAttempts).IsRequired();
            builder.Property(q => q.TotalCorrect).IsRequired();


            builder.HasMany(q => q.Options)
                   .WithOne(o => o.Question)
                   .HasForeignKey(o => o.QuestionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(q => q.AssessmentAttemptQuestions)
                   .WithOne(aq => aq.Question)
                   .HasForeignKey(aq => aq.QuestionId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(q => q.QuestionContentBlocks)
                   .WithOne(qcq => qcq.Question)
                   .HasForeignKey(qcq => qcq.QuestionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(q => q.SubTopic)
                   .WithMany(st => st.Questions)
                   .HasForeignKey(q => q.SubTopicId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
