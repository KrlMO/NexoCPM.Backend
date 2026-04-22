using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Resources.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Resources
{
    public class ResourceLikeConfiguration : IEntityTypeConfiguration<ResourceLike>
    {
        public void Configure(EntityTypeBuilder<ResourceLike> builder)
        {
            builder.ToTable("ncp_resource_like");
            builder.HasKey(rl => new { rl.ResourceId, rl.UserId });

            builder.Property(rl => rl.UserId)
                   .IsRequired();

            builder.Property(rl => rl.ResourceId)
                   .IsRequired();

            builder.HasOne(rl => rl.Resource)
                   .WithMany(r => r.ResourceLikes)
                   .HasForeignKey(rl => rl.ResourceId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rl => rl.User)
                   .WithMany(u => u.ResourceLikes)
                   .HasForeignKey(rl => rl.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
