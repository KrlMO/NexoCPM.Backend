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

        builder.Property(qcb => qcb.Type)
               .HasColumnName("type")
               .IsRequired()
               .HasConversion<int>();

        builder.Property(qcb => qcb.Role)
                .HasColumnName("role")
                .IsRequired()
                .HasConversion<int>();

        builder.Property(qcb => qcb.SourceText)
               .HasColumnName("source_text")
               .IsRequired(false);
        
        builder.Property(qcb => qcb.SourceUrl)
               .HasColumnName("source_url")
               .IsRequired(false);

        builder.Property(qcb => qcb.Title)
               .HasColumnName("title")
               .IsRequired(false);

        builder.HasIndex(qcb => qcb.Code)
               .IsUnique(true);

        builder.HasMany(qcb => qcb.QuestionContexts)
               .WithOne(q => q.QuestionContentBlock)
               .HasForeignKey(qcb => qcb.QuestionContentBlockId)
               .HasConstraintName("fk_question_content_block_question_context")
               .OnDelete(DeleteBehavior.Cascade);
    }
}