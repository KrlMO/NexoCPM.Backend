using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Resources.Entities;

namespace NexoCPM.Persistence.Configurations.Resources;

public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
{
    public void Configure(EntityTypeBuilder<Resource> builder)
    {
        builder.ToTable("ncp_resource");
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(r => r.Title)
               .HasColumnName("title")
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(r => r.Url)
               .HasColumnName("url")
               .IsRequired();

        builder.Property(r => r.Description)
               .HasColumnName("description")
               .IsRequired(false)
               .HasMaxLength(1000);

        builder.Property(r => r.IsActive)
               .HasColumnName("is_active")
               .HasDefaultValue(true);

        builder.Property(r => r.IsDeleted)
               .HasColumnName("is_deleted")
               .IsRequired()
               .HasDefaultValue(false);

        builder.Property(r => r.SubTopicId)
               .HasColumnName("sub_topic_id")
               .IsRequired(false);

        builder.Property(r => r.PublicScore)
               .HasColumnName("public_score")
                .HasDefaultValue(0)
               .IsRequired();

        builder.Property(r => r.ViewsCount)
               .HasColumnName("views_count")
               .HasDefaultValue(0)
               .IsRequired();

        builder.Property(r => r.LikesCount)
               .HasColumnName("likes_count")
               .HasDefaultValue(0)
               .IsRequired();

        builder.HasMany(r => r.UserResourceViews)
               .WithOne(rt => rt.Resource)
               .HasForeignKey(rt => rt.ResourceId)
               .HasConstraintName("fk_user_resource_view_resource")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.ResourceLikes)
               .WithOne(rl => rl.Resource)
               .HasForeignKey(rl => rl.ResourceId)
               .HasConstraintName("fk_resource_like_resource")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.SubTopic)
               .WithMany(st => st.Resources)
               .HasForeignKey(r => r.SubTopicId)
               .HasConstraintName("fk_resource_sub_topic")
               .OnDelete(DeleteBehavior.Cascade);
    }
}