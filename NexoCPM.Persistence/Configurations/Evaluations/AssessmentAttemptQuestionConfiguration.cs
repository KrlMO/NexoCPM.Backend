using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Evaluations.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Evaluations
{
    public class AssessmentAttemptQuestionConfiguration : IEntityTypeConfiguration<AssessmentAttemptQuestion>
    {
        public void Configure(EntityTypeBuilder<AssessmentAttemptQuestion> builder)
        {
            builder.ToTable("ncp_assessment_attempt_question");
            builder.HasKey(aaq => aaq.Id);

            builder.HasIndex(aaq => new { aaq.AssessmentAttemptId, aaq.QuestionId }).IsUnique();

            builder.Property(aaq => aaq.AssessmentAttemptId)
                   .IsRequired();
            builder.Property(aaq => aaq.QuestionId)
                   .IsRequired();

            builder.Property(aaq => aaq.AnsweredAt)
                   .IsRequired();
            builder.Property(aaq => aaq.SecondsSpent)
                   .IsRequired();
            builder.Property(aaq => aaq.OrderIndex)
                   .IsRequired();

            builder.HasOne(aaq => aaq.AssessmentAttempt)
                .WithMany(aa => aa.AssessmentAttemptQuestions)
                .HasForeignKey(aaq => aaq.AssessmentAttemptId);
            builder.HasOne(aaq => aaq.Question)
                .WithMany(q => q.AssessmentAttemptQuestions)
                .HasForeignKey(aaq => aaq.QuestionId);
            builder.HasOne(aaq => aaq.SelectedOption)
                .WithMany(so => so.AssessmentAttemptQuestions)
                .HasForeignKey(aaq => aaq.SelectedOptionId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
