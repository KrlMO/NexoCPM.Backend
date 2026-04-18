using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Context
{
    public class CompetenceSyllabusTopicConfiguration : IEntityTypeConfiguration<CompetenceSyllabusTopic>
    {
        public void Configure(EntityTypeBuilder<CompetenceSyllabusTopic> builder)
        {
            builder.ToTable("ncp_competence_syllabus_topic");
            builder.HasKey(x => new { x.CompetenceId, x.SyllabusTopicId });

            builder.HasOne(x => x.Competence)
                .WithMany()
                .HasForeignKey(x => x.CompetenceId);

            builder.HasOne(x => x.SyllabusTopic)
                .WithMany()
                .HasForeignKey(x => x.SyllabusTopicId);
        }
    }
}
