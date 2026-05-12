using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Curriculum.Entities;

namespace NexoCPM.Persistence.Configurations.Curriculum;

public class TopicConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.ToTable("ncp_topic");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(t => t.Code)
               .HasColumnName("code")
               .IsRequired()
               .HasMaxLength(50);

        builder.HasIndex(t => t.Code)
            .IsUnique();

        builder.Property(t => t.Description)
               .HasColumnName("description")
               .IsRequired();

        builder.Property(t => t.IsActive)
               .HasColumnName("is_active")
               .HasDefaultValue(true);

        builder.Property(t => t.IsDeleted)
               .HasColumnName("is_deleted")
               .HasDefaultValue(false);

        builder.Property(t => t.SyllabusUnitId)
               .HasColumnName("syllabus_unit_id")
               .IsRequired();

        builder.Property(t => t.OrderIndex)
               .HasColumnName("order_index")
               .IsRequired();

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

        builder.HasOne(st => st.SyllabusUnit)
               .WithMany(su => su.Topics)
               .HasForeignKey(st => st.SyllabusUnitId)
               .HasConstraintName("fk_topic_syllabus_unit")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(st => st.SubTopics)
               .WithOne(t => t.Topic)
               .HasForeignKey(t => t.TopicId)
               .HasConstraintName("fk_sub_topic_topic")
               .OnDelete(DeleteBehavior.Cascade);

        builder.Property(t => t.Slug)
            .HasColumnName("slug")
            .HasMaxLength(100)
            .IsRequired(true);

        builder.HasIndex(t => t.Slug)
            .IsUnique();

    }
}