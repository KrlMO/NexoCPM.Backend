using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Resources.Entities;

namespace NexoCPM.Persistence.Configurations.Resources;

public class ResourceLikeConfiguration : IEntityTypeConfiguration<ResourceLike>
{
    public void Configure(EntityTypeBuilder<ResourceLike> builder)
    {
        builder.ToTable("ncp_resource_like");
        builder.HasKey(rl => new { rl.ResourceId, rl.UserId });

        builder.Property(rl => rl.UserId)
               .HasColumnName("user_id")
               .IsRequired();

        builder.Property(rl => rl.ResourceId)
               .HasColumnName("resource_id")
               .IsRequired();

        builder.HasOne(rl => rl.Resource)
               .WithMany(r => r.ResourceLikes)
               .HasForeignKey(rl => rl.ResourceId)
               .HasConstraintName("fk_resource_like_resource")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(rl => rl.User)
               .WithMany(u => u.ResourceLikes)
               .HasForeignKey(rl => rl.UserId)
               .HasConstraintName("fk_resource_like_user")
               .OnDelete(DeleteBehavior.Cascade);
    }
}