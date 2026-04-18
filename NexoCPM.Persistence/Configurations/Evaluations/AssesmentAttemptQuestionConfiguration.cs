using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Evaluations.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Evaluations
{
    public class AssesmentAttemptQuestionConfiguration : IEntityTypeConfiguration<AssesmentAttemptQuestion>
    {
        public void Configure(EntityTypeBuilder<AssesmentAttemptQuestion> builder)
        {
            builder.ToTable("ncp_assesment_attempt_question");
        }
    }
}
