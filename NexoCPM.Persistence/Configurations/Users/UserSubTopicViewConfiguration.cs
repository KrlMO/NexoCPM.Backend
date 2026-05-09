using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Users.Entities;

namespace NexoCPM.Persistence.Configurations.Users;

public class UserSubTopicViewConfiguration : IEntityTypeConfiguration<UserSubTopicView>
{
    public void Configure(EntityTypeBuilder<UserSubTopicView> builder)
    {
        builder.ToTable("ncp_user_sub_topic_view");
        builder.HasKey(ustv => new { ustv.UserSyllabusUnitProgressId, ustv.SubTopicId });

        builder.Property(ustv => ustv.UserSyllabusUnitProgressId)
               .HasColumnName("user_syllabus_unit_progress_id")
               .IsRequired();

        builder.Property(ustv => ustv.SubTopicId)
               .HasColumnName("sub_topic_id")
               .IsRequired();

        builder.Property(ustv => ustv.IsViewed)
               .HasColumnName("is_viewed")
               .IsRequired()
               .HasDefaultValue(false);

        builder.Property(ustv => ustv.ViewedAt)
               .HasColumnName("viewed_at");

        builder.HasOne(ustv => ustv.UserSyllabusUnitProgress)
               .WithMany(usup => usup.UserSubTopicViews)
               .HasForeignKey(ustv => ustv.UserSyllabusUnitProgressId)
               .HasConstraintName("fk_user_sub_topic_view_unit_progress")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(ustv => ustv.SubTopic)
               .WithMany(st => st.UserSubTopicViews)
               .HasForeignKey(ustv => ustv.SubTopicId)
               .HasConstraintName("fk_user_sub_topic_view_sub_topic")
               .OnDelete(DeleteBehavior.NoAction);
    }
}
