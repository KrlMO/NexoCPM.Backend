using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Curriculum.Entities;

namespace NexoCPM.Persistence.Configurations.Curriculum;

public class SubTopicConfiguration : IEntityTypeConfiguration<SubTopic>
{
    public void Configure(EntityTypeBuilder<SubTopic> builder)
    {
        builder.ToTable("ncp_sub_topic");
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

        builder.Property(sb => sb.Description)
            .HasColumnName("description")
            .IsRequired();

        builder.Property(t => t.OrderIndex)
               .HasColumnName("order_index")
               .IsRequired();

        builder.Property(t => t.TopicId)
               .HasColumnName("topic_id")
               .IsRequired();

        builder.Property(t => t.IsActive)
               .HasColumnName("is_active")
               .HasDefaultValue(true);

        builder.Property(t => t.IsDeleted)
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

        builder.HasOne(t => t.Topic)
               .WithMany(st => st.SubTopics)
               .HasForeignKey(t => t.TopicId)
               .HasConstraintName("fk_sub_topic_topic")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.MicroTopics)
               .WithOne(st => st.SubTopic)
               .HasForeignKey(st => st.SubTopicId)
               .HasConstraintName("fk_micro_topic_sub_topic")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.Questions)
               .WithOne(qt => qt.SubTopic)
               .HasForeignKey(qt => qt.SubTopicId)
               .HasConstraintName("fk_question_sub_topic")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(st => st.Resources)
               .WithOne(r => r.SubTopic)
               .HasForeignKey(r => r.SubTopicId)
               .HasConstraintName("fk_resource_sub_topic")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(st => st.Competence)
            .WithMany(cl => cl.SubTopics)
            .HasForeignKey(cl => cl.CompetenceId)
            .HasConstraintName("fk_sub_topic_competence")
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.Property(st => st.Slug)
            .HasColumnName("slug")
            .HasMaxLength(100)
            .IsRequired(true);

        builder.HasIndex(st => st.Slug)
            .IsUnique();
    }
}