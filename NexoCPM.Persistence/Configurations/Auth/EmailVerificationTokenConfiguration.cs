using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Auth.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Auth
{
    public class EmailVerificationTokenConfiguration : IEntityTypeConfiguration<EmailVerificationToken>
    {
        public void Configure(EntityTypeBuilder<EmailVerificationToken> builder)
        {
            builder.ToTable("ncp_email_verification_token");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("id")
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.TokenHash)
                .HasColumnName("token_hash")
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(e => e.CreatedAt)
                   .HasColumnName("created_at")
                   .IsRequired();

            builder.Property(e => e.ExpiresAt)
                    .HasColumnName("expires_at")
                   .IsRequired();

            builder.Property(e => e.IsUsed)
                   .HasColumnName("is_used")
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.Property(e => e.UsedAt)
                   .HasColumnName("used_at")
                   .IsRequired(false);

            builder.Property(e => e.UserId)
                   .HasColumnName("user_id")
                   .IsRequired();

            builder.HasOne(e => e.User)
                   .WithMany(u => u.EmailVerificationTokens)
                   .HasForeignKey(e => e.UserId)
                   .HasConstraintName("fk_email_verification_token_user")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
