using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Evaluations.Entities;

namespace NexoCPM.Persistence.Configurations.Evaluations;

public class OptionBlockConfiguration : IEntityTypeConfiguration<OptionBlock>
{
    public void Configure(EntityTypeBuilder<OptionBlock> builder)
    {
        builder.ToTable("ncp_option_block");
        builder.HasKey(ob => ob.Id);

        builder.Property(ob => ob.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(ob => ob.OptionId)
               .HasColumnName("option_id")
               .IsRequired();

        builder.Property(ob => ob.Content)
               .HasColumnName("content")
               .IsRequired();

        builder.Property(ob => ob.Type)
               .HasColumnName("type")
               .IsRequired()
               .HasConversion<int>();

        builder.Property(ob => ob.OrderIndex)
               .HasColumnName("order_index")
               .IsRequired();

        builder.HasOne(ob => ob.Option)
               .WithMany(o => o.OptionBlocks)
               .HasForeignKey(ob => ob.OptionId)
               .HasConstraintName("fk_option_block_option")
               .OnDelete(DeleteBehavior.Cascade);
    }
}
