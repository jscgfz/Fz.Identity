using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finanzauto.Identity.Api.Database.Configuration.Identity;

public sealed class ContactInfoConfiguration : IEntityTypeConfiguration<ContactInfo>
{
  public void Configure(EntityTypeBuilder<ContactInfo> builder)
  {
    builder.ToTable(nameof(ContactInfo), IdentitySchemas.Identity);
    builder.HasKey(row => row.UserId);
    builder.HasIndex(row => row.Email).IsUnique();
    builder.HasIndex(row => row.PhoneNumber).IsUnique();
    builder.Property(row => row.Email).HasMaxLength(50);
    builder.Property(row => row.PhoneNumber).HasMaxLength(20);
    builder.Property(row => row.EmailConfirmed).HasDefaultValue(false);
    builder.Property(row => row.PhoneNumberConfirmed).HasDefaultValue(false);
    builder.HasOne(row => row.User)
      .WithOne(row => row.ContactInfo)
      .HasForeignKey<ContactInfo>(row => row.UserId)
      .OnDelete(DeleteBehavior.NoAction);
  }
}