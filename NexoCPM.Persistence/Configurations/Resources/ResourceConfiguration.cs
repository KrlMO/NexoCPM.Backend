using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Resources.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Resources
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.ToTable("ncp_resource");

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Title)
                   .IsRequired()
                   .HasMaxLength(200);
            builder.Property(r => r.Url)
                   .IsRequired();

            builder.Property(r => r.Description)
                .IsRequired(false)
                   .HasMaxLength(1000);

            builder.Property(r => r.IsActive)
                   .IsRequired();
            builder.Property(r => r.SubTopicId)
                   .IsRequired(false);

            builder.Property(r => r.IsDeleted)
                   .IsRequired();

            builder.Property(r => r.PublicScore)
                   .IsRequired();
            builder.Property(r => r.ViewsCount)
                   .IsRequired();
            builder.Property(r => r.LikesCount)
                .IsRequired();

            builder.HasMany(r => r.UserResourceViews)
                   .WithOne(rt => rt.Resource)
                   .HasForeignKey(rt => rt.ResourceId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.ResourceLikes)
                   .WithOne(rl => rl.Resource)
                   .HasForeignKey(rl => rl.ResourceId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.SubTopic)
                   .WithMany(st => st.Resources)
                   .HasForeignKey(r => r.SubTopicId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
