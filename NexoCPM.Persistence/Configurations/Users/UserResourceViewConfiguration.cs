using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Users.Entities;

namespace NexoCPM.Persistence.Configurations.Users;

public class UserResourceViewConfiguration : IEntityTypeConfiguration<UserResourceView>
{
    public void Configure(EntityTypeBuilder<UserResourceView> builder)
    {
        builder.ToTable("ncp_user_resource_view");
        builder.HasKey(urv => new { urv.UserId, urv.ResourceId });

        builder.Property(urv => urv.UserId)
               .HasColumnName("user_id")
               .IsRequired();

        builder.Property(urv => urv.ResourceId)
               .HasColumnName("resource_id")
               .IsRequired();

        builder.Property(urv => urv.ViewedAt)
               .HasColumnName("viewed_at")
               .IsRequired();

        builder.HasOne(urv => urv.User)
               .WithMany(u => u.UserResourceViews)
               .HasForeignKey(urv => urv.UserId)
               .HasConstraintName("fk_user_resource_view_user")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(urv => urv.Resource)
               .WithMany(r => r.UserResourceViews)
               .HasForeignKey(urv => urv.ResourceId)
               .HasConstraintName("fk_user_resource_view_resource")
               .OnDelete(DeleteBehavior.Cascade);
    }
}