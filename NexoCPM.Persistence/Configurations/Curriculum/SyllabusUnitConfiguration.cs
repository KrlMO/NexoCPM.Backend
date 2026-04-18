using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Curriculum.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Curriculum
{
    public class SyllabusUnitConfiguration : IEntityTypeConfiguration<SyllabusUnit>
    {
        public void Configure(EntityTypeBuilder<SyllabusUnit> builder)
        {
            builder.ToTable("ncp_syllabus_unit");
        }
    }
}
