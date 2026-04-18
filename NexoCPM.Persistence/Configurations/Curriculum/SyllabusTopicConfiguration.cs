using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Curriculum.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Curriculum
{
    public class SyllabusTopicConfiguration : IEntityTypeConfiguration<SyllabusTopic>
    {
        public void Configure(EntityTypeBuilder<SyllabusTopic> builder)
        {
            builder.ToTable("ncp_syllabus_topic");
        }
    }
}
