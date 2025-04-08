using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fz.Identity.Api.Database.Configuration;

public sealed class UserAplicationConfiguration : IEntityTypeConfiguration<UserApplication>
{
  public void Configure(EntityTypeBuilder<UserApplication> builder)
  {
    builder.ToTable("UserApplications", IdentityContextSchemas.Configuration);
    builder.HasKey(x => new { x.UserId, x.ApplicationId });
    builder
      .HasOne(row => row.User)
      .WithMany(row => row.Applications)
      .HasForeignKey(row => row.UserId)
      .OnDelete(DeleteBehavior.NoAction);
    builder
      .HasOne(row => row.Application)
      .WithMany(row => row.Users)
      .HasForeignKey(row => row.ApplicationId)
      .OnDelete(DeleteBehavior.NoAction);
    builder
      .HasData([
        new() { UserId = Guid.Parse("5ea12c28-b655-41e6-be6c-ed56c781d30b"), ApplicationId = 7 },
        new() { UserId = Guid.Parse("f465489e-f743-40c2-8585-3ebdc982ac5e"), ApplicationId = 7 },
        new() { UserId = Guid.Parse("aa6a6abd-4c02-45ee-92e4-9ad4cc31169c"), ApplicationId = 7 },
        new() { UserId = Guid.Parse("8d7e4c06-16d7-4448-b145-bda5f1af0776"), ApplicationId = 7 },
      ]);
  }
}
