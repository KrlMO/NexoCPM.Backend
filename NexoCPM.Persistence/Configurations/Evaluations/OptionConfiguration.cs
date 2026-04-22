using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Evaluations.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Evaluations
{
    public class OptionConfiguration : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.ToTable("ncp_option");
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Text)
                   .IsRequired();

            builder.Property(o => o.IsCorrect)
                   .IsRequired();

            builder.HasOne(o => o.Question)
                   .WithMany(q => q.Options)
                   .HasForeignKey(o => o.QuestionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(o => o.AssessmentAttemptQuestions)
                   .WithOne(aq => aq.SelectedOption)
                   .HasForeignKey(aq => aq.SelectedOptionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}