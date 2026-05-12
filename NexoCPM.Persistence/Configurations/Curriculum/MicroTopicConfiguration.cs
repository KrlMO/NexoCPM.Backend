using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Curriculum.Entities;

namespace NexoCPM.Persistence.Configurations.Curriculum;

public class MicroTopicConfiguration : IEntityTypeConfiguration<MicroTopic>
{
    public void Configure(EntityTypeBuilder<MicroTopic> builder)
    {
        builder.ToTable("ncp_micro_topic");
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(s => s.Code)
               .HasColumnName("code")
               .IsRequired()
               .HasMaxLength(50);

        builder.HasIndex(s => s.Code)
            .IsUnique();

        builder.Property(s => s.OrderIndex)
               .HasColumnName("order_index")
               .IsRequired();

        builder.Property(s => s.SubTopicId)
               .HasColumnName("sub_topic_id")
               .IsRequired();

        builder.Property(s => s.IsActive)
               .HasColumnName("is_active")
               .HasDefaultValue(true);

        builder.Property(s => s.IsDeleted)
               .HasColumnName("is_deleted")
               .HasDefaultValue(false);

        builder.Property(t => t.CreatedAt)
               .HasColumnName("created_at")
               .IsRequired()
               .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(t => t.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired(false);

        builder.Property(t => t.DeletedAt)
               .HasColumnName("deleted_at")
               .IsRequired(false);

        builder.Property(t => t.CreatedBy)
               .HasColumnName("created_by")
               .IsRequired(true)
               .HasDefaultValue(1);

        builder.Property(t => t.UpdatedBy)
                .HasColumnName("updated_by")
                .IsRequired(false)
               .HasDefaultValue(1);

        builder.Property(t => t.DeletedBy)
               .HasColumnName("deleted_by")
               .IsRequired(false);

        builder.HasOne(s => s.SubTopic)
               .WithMany(t => t.MicroTopics)
               .HasForeignKey(s => s.SubTopicId)
               .HasConstraintName("fk_micro_topic_sub_topic")
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(mt => mt.Slug)
            .HasColumnName("slug")
            .HasMaxLength(200)
            .IsRequired(true);

        builder.HasIndex(mt => mt.Slug)
            .IsUnique();
        builder.Property(mt => mt.Description)
            .HasColumnName("description");
    }
}