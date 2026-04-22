using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Users.Entities;

namespace NexoCPM.Persistence.Configurations.Users
{
    public class UserSyllabusProgressConfiguration : IEntityTypeConfiguration<UserSyllabusProgress>
    {
        public void Configure(EntityTypeBuilder<UserSyllabusProgress> builder)
        {
            builder.ToTable("ncp_user_syllabus_progress");
            builder.HasKey(usp => usp.Id);

            builder.HasIndex(usp => usp.UserLearningContextId)
                   .IsUnique();

            builder.Property(usp => usp.UserLearningContextId).IsRequired();

            builder.Property(usp => usp.LastAccess)
                   .IsRequired();

            builder.Property(usp => usp.Status)
                   .HasConversion<int>()
                   .IsRequired();

            builder.HasOne(usp => usp.UserLearningContext)
                   .WithOne(ulc => ulc.UserSyllabusProgress)
                   .HasForeignKey<UserSyllabusProgress>(usp => usp.UserLearningContextId)
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}