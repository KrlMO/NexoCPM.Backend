using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Evaluations.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Evaluations
{
    public class AssessmentConfiguration : IEntityTypeConfiguration<Assessment>
    {
        public void Configure(EntityTypeBuilder<Assessment> builder)
        {
            builder.ToTable("ncp_assessment");
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Code)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.HasIndex(a => a.Code).IsUnique();

            builder.Property(a => a.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(a => a.Type)
               .IsRequired().HasConversion<int>();

            builder.Property(a => a.Scope)
                   .IsRequired().HasConversion<int>();

            builder.Property(a => a.TargetId)
               .IsRequired(false);

            builder.Property(a => a.IsActive)
                   .IsRequired();

            builder.Property(a => a.IsActive)
               .IsRequired();

            builder.Property(a => a.TimeLimitSeconds)
                   .IsRequired(false);

            builder.Property(a => a.NumberQuestions)
               .IsRequired();

            builder.Property(a => a.MaxAttempts)
                           .IsRequired(false);

            builder.HasMany(a => a.AssessmentAttempts)
               .WithOne(aa => aa.Assessment)
               .HasForeignKey(aa => aa.AssessmentId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(a => new { a.Scope, a.TargetId });
        }
    }
}
