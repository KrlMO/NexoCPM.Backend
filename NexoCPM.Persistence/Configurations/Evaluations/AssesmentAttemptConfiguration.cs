using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Evaluations.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Evaluations
{
    public class AssesmentAttemptConfiguration : IEntityTypeConfiguration<AssesmentAttempt>
    {
        public void Configure(EntityTypeBuilder<AssesmentAttempt> builder)
        {
            builder.ToTable("ncp_assesment_attempt");
        }
    }
}
