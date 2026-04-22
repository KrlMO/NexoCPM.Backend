using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Users.Entities;

namespace NexoCPM.Persistence.Configurations.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("ncp_user");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.AvatarUrl)
                   .HasMaxLength(500);

            builder.Property(u => u.Bio)
                   .HasMaxLength(500);

            builder.Property(u => u.DateOfBirth);

            builder.Property(u => u.Location)
                   .HasMaxLength(200);

            builder.Property(u => u.PhoneNumber)
                   .HasMaxLength(20);

            builder.Property(u => u.LinkedInProfile)
                   .HasMaxLength(200);

            builder.Property(u => u.Code)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(u => u.FirstName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.LastName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.UserName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(u => u.PasswordHash)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(u => u.UserRole)
                   .HasConversion<string>()
                   .IsRequired();

            builder.Property(u => u.IsActive)
                   .IsRequired();

            builder.Property(u => u.IsVerified)
                   .IsRequired();

            builder.Property(u => u.IsDeleted)
                   .IsRequired();

            builder.HasIndex(u => u.Email).IsUnique();
            builder.HasIndex(u => u.UserName).IsUnique();
            builder.HasIndex(u => u.Code).IsUnique();
        }
    }
}
