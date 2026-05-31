using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Evaluations.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Evaluations
{
    public class QuestionContextConfiguration : IEntityTypeConfiguration<QuestionContext>
    {
        public void Configure(EntityTypeBuilder<QuestionContext> builder)
        {
            builder.ToTable("ncp_question_context");
            builder.HasKey(qc => new { qc.QuestionId, qc.QuestionContentBlockId });
            builder.HasIndex(qc => new { qc.QuestionId, qc.OrderIndex }).IsUnique();

            builder.Property(qc => qc.QuestionContentBlockId)
                .HasColumnName("question_content_block_id")
                .IsRequired();

            builder.Property(qc => qc.QuestionId).
                HasColumnName("question_id")
                .IsRequired();

            builder.HasOne(qc => qc.Question)
                .WithMany(q => q.QuestionContexts)
                .HasForeignKey(qc => qc.QuestionId);
            builder.HasOne(qc => qc.QuestionContentBlock)
                .WithMany(qcb => qcb.QuestionContexts)
                .HasForeignKey(qc => qc.QuestionContentBlockId);

            builder.Property(qc => qc.OrderIndex)
                .HasColumnName("order_index")
                .IsRequired();
        }
    }
}
