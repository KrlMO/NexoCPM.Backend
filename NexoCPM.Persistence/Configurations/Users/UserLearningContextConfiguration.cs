using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Users
{
    public class UserLearningContextConfiguration : IEntityTypeConfiguration<UserLearningContext>
    {
        public void Configure(EntityTypeBuilder<UserLearningContext> builder)
        {
            builder.ToTable("ncp_user_learning_context");
            builder.HasKey(ulc => ulc.Id);

            builder.Property(ulc => ulc.UserId).IsRequired();
            builder.Property(ulc => ulc.SyllabusId).IsRequired();

            builder.Property(ulc => ulc.IsActive).IsRequired();
            builder.Property(ulc => ulc.IsDeleted).IsRequired();

            builder.HasOne(ulc => ulc.UserSyllabusProgress)
                   .WithOne(usp => usp.UserLearningContext)
                   .HasForeignKey<UserSyllabusProgress>(usp => usp.UserLearningContextId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(ulc => ulc.User)
                   .WithMany(u => u.UserLearningContexts)
                   .HasForeignKey(ulc => ulc.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(ulc => ulc.Syllabus)
                   .WithMany(s => s.UserLearningContexts)
                   .HasForeignKey(ulc => ulc.SyllabusId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(ulc => ulc.AssessmentAttempts)
                   .WithOne(usup => usup.UserLearningContext)
                   .HasForeignKey(usup => usup.UserLearningContextId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
