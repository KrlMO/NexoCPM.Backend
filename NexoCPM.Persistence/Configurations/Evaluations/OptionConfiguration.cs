using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Evaluations.Entities;

namespace NexoCPM.Persistence.Configurations.Evaluations;

public class OptionConfiguration : IEntityTypeConfiguration<Option>
{
    public void Configure(EntityTypeBuilder<Option> builder)
    {
        builder.ToTable("ncp_option");
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(o => o.Text)
               .HasColumnName("text")
               .IsRequired();

        builder.Property(o => o.IsCorrect)
               .HasColumnName("is_correct")
               .IsRequired();

        builder.Property(o => o.QuestionId)
               .HasColumnName("question_id")
               .IsRequired();

        builder.HasOne(o => o.Question)
               .WithMany(q => q.Options)
               .HasForeignKey(o => o.QuestionId)
               .HasConstraintName("fk_option_question")
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(o => o.AssessmentAttemptQuestions)
               .WithOne(aq => aq.SelectedOption)
               .HasForeignKey(aq => aq.SelectedOptionId)
               .HasConstraintName("fk_assessment_attempt_question_selected_option")
               .OnDelete(DeleteBehavior.Cascade);
    }
}