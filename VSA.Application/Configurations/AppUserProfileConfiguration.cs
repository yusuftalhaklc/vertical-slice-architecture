using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VSA.Application.Entities;

namespace VSA.Application.Configurations
{
    public class AppUserProfileConfiguration : IEntityTypeConfiguration<AppUserProfile>
    {
        public void Configure(EntityTypeBuilder<AppUserProfile> builder)
        {
            // Table Name
            builder.ToTable("AppUserProfiles");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Properties
            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.AppUserId)
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .IsRequired();

            builder.Property(x => x.UpdatedDate)
                .IsRequired(false);

            builder.Property(x => x.DeletedDate)
                .IsRequired(false);

            // Relationships
            builder.HasOne(x => x.AppUser)
                .WithOne(x => x.AppUserProfile)
                .HasForeignKey<AppUserProfile>(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            builder.HasIndex(x => x.AppUserId)
                .IsUnique();
        }
    }
}

