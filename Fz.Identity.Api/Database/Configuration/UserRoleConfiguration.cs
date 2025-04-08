using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Database.Configuration;

public sealed class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
  public void Configure(EntityTypeBuilder<UserRole> builder)
  {
    builder.ToTable("UserRoles", IdentityContextSchemas.Auth);
    builder
      .HasKey(row => new { row.UserId, row.RoleId });
    builder
      .HasOne(row => row.User)
      .WithMany(row => row.Roles)
      .HasForeignKey(row => row.UserId);
    builder
      .HasOne(row => row.Role)
      .WithMany(row => row.UserRoles)
      .HasForeignKey(row => row.RoleId);
    builder
      .HasData([
        new UserRole { UserId = Guid.Parse("5ea12c28-b655-41e6-be6c-ed56c781d30b"), RoleId = Guid.Parse("228ee2e2-843e-47cc-98ff-ae78e52340b7") },
        new UserRole { UserId = Guid.Parse("f465489e-f743-40c2-8585-3ebdc982ac5e"), RoleId = Guid.Parse("07fcaa8e-7062-4c31-b582-8285784afd68") },
        new UserRole { UserId = Guid.Parse("aa6a6abd-4c02-45ee-92e4-9ad4cc31169c"), RoleId = Guid.Parse("89789f4a-570d-451d-b99b-69127421f1fe") },
        new UserRole { UserId = Guid.Parse("8d7e4c06-16d7-4448-b145-bda5f1af0776"), RoleId = Guid.Parse("8c187a8e-a65a-45a1-a29b-49c99e1b3cff") },
      ]);
  }
}
