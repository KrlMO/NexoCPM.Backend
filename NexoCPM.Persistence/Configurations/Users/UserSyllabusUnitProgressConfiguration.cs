using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Users.Entities;

namespace NexoCPM.Persistence.Configurations.Users
{
    public class UserSyllabusUnitProgressConfiguration : IEntityTypeConfiguration<UserSyllabusUnitProgress>
    {
        public void Configure(EntityTypeBuilder<UserSyllabusUnitProgress> builder)
        {
            builder.ToTable("ncp_user_syllabus_unit_progress");
            builder.HasKey(usup => usup.Id);

            builder.HasIndex(usup => new { usup.UserSyllabusProgressId, usup.SyllabusUnitId })
                   .IsUnique();


            builder.Property(usup => usup.SyllabusUnitId)
                   .IsRequired();
            builder.Property(usup => usup.UserSyllabusProgressId)
                   .IsRequired();

            builder.Property(usup => usup.Status)
                   .HasConversion<int>()
                   .IsRequired();

            builder.Property(usup => usup.Attempts)
                   .IsRequired();

            builder.Property(usup => usup.LastAttemptAt)
                   .IsRequired();

            builder.Property(usup => usup.TotalQuestions)
                   .IsRequired();

            builder.Property(usup => usup.TotalCorrect)
                   .IsRequired();

            builder.HasOne(usup => usup.SyllabusUnit)
                   .WithMany(su => su.UserSyllabusUnitProgresses)
                   .HasForeignKey(usup => usup.SyllabusUnitId)
                   .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(usup => usup.UserSyllabusProgress)
                   .WithMany()
                   .HasForeignKey(usup => usup.UserSyllabusProgressId)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired(false);
        }
    }
}