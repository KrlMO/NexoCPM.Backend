using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Evaluations.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Evaluations
{
    public class QuestionContentBlockConfiguration : IEntityTypeConfiguration<QuestionContentBlock>
    {
        public void Configure(EntityTypeBuilder<QuestionContentBlock> builder)
        {
            builder.ToTable("ncp_question_content_block");
            builder.HasKey(qcb => qcb.Id);

            builder.Property(qcb => qcb.Content).IsRequired();
            builder.Property(qcb => qcb.QuestionId).IsRequired();

            builder.Property(qcb => qcb.Code)
                   .IsRequired()
                   .HasMaxLength(20);
            builder.HasIndex(qcb => qcb.Code)
                   .IsUnique();

            builder.Property(qcb => qcb.OrderIndex).IsRequired();

            builder.HasOne(qcb => qcb.Question)
                   .WithMany(q => q.QuestionContentBlocks)
                   .HasForeignKey(qcb => qcb.QuestionId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(qcb => qcb.Type)
                        .IsRequired().HasConversion<int>();

        }
    }
}
