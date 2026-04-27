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
               .HasMaxLength(20);

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
               .IsRequired(true);
        builder.Property(t => t.UpdatedBy)
                .HasColumnName("updated_by")
                .IsRequired(false);

        builder.Property(t => t.DeletedBy)
               .HasColumnName("deleted_by")
               .IsRequired(false);

        builder.HasOne(s => s.SubTopic)
               .WithMany(t => t.MicroTopics)
               .HasForeignKey(s => s.SubTopicId)
               .HasConstraintName("fk_micro_topic_sub_topic")
               .OnDelete(DeleteBehavior.Cascade);
    }
}