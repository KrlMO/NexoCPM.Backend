using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NexoCPM.Domain.Users.Entities;

namespace NexoCPM.Persistence.Configurations.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("ncp_user");
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
               .HasColumnName("id")
               .ValueGeneratedOnAdd();

        builder.Property(u => u.AvatarUrl)
               .HasColumnName("avatar_url")
               .HasMaxLength(500);

        builder.Property(u => u.Bio)
               .HasColumnName("bio")
               .HasMaxLength(500);

        builder.Property(u => u.DateOfBirth)
               .HasColumnName("date_of_birth");

        builder.Property(u => u.Location)
               .HasColumnName("location")
               .HasMaxLength(200);

        builder.Property(u => u.PhoneNumber)
               .HasColumnName("phone_number")
               .HasMaxLength(20);

        builder.Property(u => u.LinkedInProfile)
               .HasColumnName("linkedin_profile")
               .HasMaxLength(200);

        builder.Property(u => u.Code)
               .HasColumnName("code")
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(u => u.FirstName)
               .HasColumnName("first_name")
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(u => u.LastName)
               .HasColumnName("last_name")
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(u => u.UserName)
               .HasColumnName("user_name")
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(u => u.Email)
               .HasColumnName("email")
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(u => u.PasswordHash)
               .HasColumnName("password_hash")
               .IsRequired()
               .HasMaxLength(500);

        builder.Property(u => u.SecurityStamp)
               .HasColumnName("security_stamp")
               .IsRequired()
               .HasMaxLength(64);

        builder.Property(u => u.UserRole)
               .HasColumnName("user_role")
               .HasConversion<string>()
               .IsRequired();

        builder.Property(u => u.IsActive)
               .HasColumnName("is_active")
               .IsRequired()
               .HasDefaultValue(true);

        builder.Property(u => u.IsVerified)
               .HasColumnName("is_verified")
               .IsRequired()
               .HasDefaultValue(false);

        builder.Property(u => u.IsDeleted)
               .HasColumnName("is_deleted")
               .IsRequired()
               .HasDefaultValue(false);

        builder.Property(t => t.CreatedAt)
               .HasColumnName("created_at")
               .IsRequired()
               .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(t => t.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired(false);

        builder.Property(t => t.DeletedAt)
               .HasColumnName("deleted_at")
               .IsRequired(false);

        builder.Property(t => t.CreatedBy)
               .HasColumnName("created_by")
               .IsRequired(true)
			   .HasDefaultValue(1);

        builder.Property(t => t.UpdatedBy)
                .HasColumnName("updated_by")
                .IsRequired(false)
			   .HasDefaultValue(1);

        builder.Property(t => t.DeletedBy)
               .HasColumnName("deleted_by")
               .IsRequired(false);

        builder.Property(u => u.IsPublic)
            .HasColumnName("is_public")
            .IsRequired()
            .HasDefaultValue(true);

        builder.HasIndex(u => u.Email).IsUnique(true);
        builder.HasIndex(u => u.UserName).IsUnique(true);
        builder.HasIndex(u => u.Code).IsUnique(true);
    }
}