using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Auth.Entities;

namespace NexoCPM.Persistence.Configurations.Auth
{
    public class PasswordResetTokenConfiguration : IEntityTypeConfiguration<PasswordResetToken>
    {
        public void Configure(EntityTypeBuilder<PasswordResetToken> builder)
        {
            builder.ToTable("ncp_password_reset_token");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnName("id")
                   .ValueGeneratedOnAdd();

            builder.Property(e => e.UserId)
                   .HasColumnName("user_id")
                   .IsRequired();

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

            builder.Property(e => e.RequestedIp)
                   .HasColumnName("requested_ip")
                   .HasMaxLength(45)
                   .IsRequired(false);

            builder.Property(e => e.UserAgent)
                   .HasColumnName("user_agent")
                   .HasMaxLength(500)
                   .IsRequired(false);

            builder.HasOne(e => e.User)
                   .WithMany(u => u.PasswordResetTokens)
                   .HasForeignKey(e => e.UserId)
                   .HasConstraintName("fk_password_reset_token_user")
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
