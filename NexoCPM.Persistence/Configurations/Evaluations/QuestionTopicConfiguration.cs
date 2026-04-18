using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Evaluations.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NexoCPM.Persistence.Configurations.Evaluations
{
    public class QuestionTopicConfiguration : IEntityTypeConfiguration<QuestionTopic>
    {
        public void Configure(EntityTypeBuilder<QuestionTopic> builder)
        {
            builder.ToTable("ncp_question_topic");
        }
    }
}
