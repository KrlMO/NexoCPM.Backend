using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Evaluations.Entities;

namespace NexoCPM.Persistence.Configurations.Evaluations;

public class QuestionContentBlockConfiguration : IEntityTypeConfiguration<QuestionContentBlock>
{
    public void Configure(EntityTypeBuilder<QuestionContentBlock> builder)
    {
        builder.ToTable("ncp_question_content_block");
        builder.HasKey(qcb => qcb.Id);

        builder.Property(qcb => qcb.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(qcb => qcb.Code)
               .HasColumnName("code")
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(qcb => qcb.Content)
               .HasColumnName("content")
               .IsRequired();

        builder.Property(qcb => qcb.QuestionId)
               .HasColumnName("question_id")
               .IsRequired();

        builder.Property(qcb => qcb.OrderIndex)
               .HasColumnName("order_index")
               .IsRequired();

        builder.Property(qcb => qcb.Type)
               .HasColumnName("type")
               .IsRequired()
               .HasConversion<int>();

        builder.HasIndex(qcb => qcb.Code)
               .IsUnique(true);

        builder.HasOne(qcb => qcb.Question)
               .WithMany(q => q.QuestionContentBlocks)
               .HasForeignKey(qcb => qcb.QuestionId)
               .HasConstraintName("fk_question_content_block_question")
               .OnDelete(DeleteBehavior.Cascade);
    }
}