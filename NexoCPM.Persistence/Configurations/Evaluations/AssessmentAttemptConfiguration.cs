using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Evaluations.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Evaluations
{
    public class AssessmentAttemptConfiguration : IEntityTypeConfiguration<AssessmentAttempt>
    {
        public void Configure(EntityTypeBuilder<AssessmentAttempt> builder)
        {
            builder.ToTable("ncp_assesment_attempt");

            builder.HasKey(aa => aa.Id);

            builder.Property(aa => aa.AssessmentId)
                .IsRequired();

            builder.Property(aa => aa.StartedAt)
                .IsRequired();
            builder.Property(aa => aa.FinishedAt)
                .IsRequired();

            builder.HasOne(aa => aa.Assessment)
                   .WithMany()
                   .HasForeignKey(aa => aa.AssessmentId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(aa => aa.AssessmentAttemptQuestions)
                   .WithOne(aq => aq.AssessmentAttempt)
                   .HasForeignKey(aq => aq.AssessmentAttemptId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(aa => aa.UserLearningContext)
                   .WithMany()
                   .HasForeignKey(aa => aa.UserLearningContextId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
