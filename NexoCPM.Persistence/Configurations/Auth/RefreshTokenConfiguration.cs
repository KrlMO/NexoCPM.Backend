using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Auth.Entities;

namespace NexoCPM.Persistence.Configurations.Auth;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("ncp_refresh_token");
        builder.HasKey(rt => rt.Id);

        builder.Property(rt => rt.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(rt => rt.UserId)
               .HasColumnName("user_id")
               .IsRequired();

        builder.Property(rt => rt.DeviceInfo)
               .HasColumnName("device_info")
               .HasMaxLength(500);

        builder.Property(rt => rt.IpAddress)
               .HasColumnName("ip_address")
               .HasMaxLength(45);

        builder.Property(rt => rt.Token)
               .HasColumnName("token")
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(rt => rt.CreatedAt)
               .HasColumnName("created_at")
               .IsRequired();

        builder.Property(rt => rt.ExpiresAt)
               .HasColumnName("expires_at")
               .IsRequired();

        builder.Property(rt => rt.Revoked)
               .HasColumnName("revoked")
               .IsRequired()
               .HasDefaultValue(false);

        builder.Property(rt => rt.RevokedAt)
               .HasColumnName("revoked_at")
               .IsRequired(false);

        builder.HasIndex(rt => rt.Token).IsUnique(true);

        builder.HasOne(rt => rt.User)
               .WithMany(u => u.RefreshTokens)
               .HasForeignKey(rt => rt.UserId)
               .HasConstraintName("fk_refresh_token_user")
               .OnDelete(DeleteBehavior.Cascade);
    }
}