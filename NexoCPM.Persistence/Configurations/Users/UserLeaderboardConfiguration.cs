using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Users.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Users
{
    public class UserLeaderboardConfiguration : IEntityTypeConfiguration<UserLeaderboard>
    {
        public void Configure(EntityTypeBuilder<UserLeaderboard> builder)
        {
            builder.ToTable("ncp_user_leaderboard");
            builder.HasKey(ul => ul.UserId);

            builder.Property(ul => ul.UserId)
                   .HasColumnName("user_id")
                   .ValueGeneratedNever();

            builder.Property(ul => ul.TotalStars)
                   .HasColumnName("total_stars")
                   .IsRequired()
                   .HasDefaultValue(0);

            builder.Property(ul => ul.LastUpdated)
                   .HasColumnName("last_updated")
                   .IsRequired()
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(ul => ul.User)
                   .WithOne(u => u.UserLeaderboard)
                   .HasForeignKey<UserLeaderboard>(ul => ul.UserId)
                   .HasConstraintName("fk_user_leaderboard_user")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}