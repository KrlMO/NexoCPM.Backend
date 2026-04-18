using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Context.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Context
{
    public class EducationContextConfiguration : IEntityTypeConfiguration<EducationContext>
    {
        public void Configure(EntityTypeBuilder<EducationContext> builder)
        {
            builder.ToTable("ncp_education_context");
        }
    }
}
