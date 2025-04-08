using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Fz.Identity.Api.Abstractions.Persistence;

namespace Fz.Identity.Api.Database.Configuration;

public sealed class RoleConfiguration(IIdentityContextControlFieldsManager manager) : IEntityTypeConfiguration<Role>
{
  private readonly IIdentityContextControlFieldsManager _manager = manager;

  public void Configure(EntityTypeBuilder<Role> builder)
  {
    builder.ToTable("Roles", IdentityContextSchemas.Auth);
    builder
      .HasIndex(row => new { row.ApplicationId, row.Name })
      .IsUnique();
    builder
      .HasOne(row => row.Application)
      .WithMany(row => row.Roles)
      .HasForeignKey(row => row.ApplicationId);
    builder
      .HasData([
        new Role { Id = Guid.Parse("07fcaa8e-7062-4c31-b582-8285784afd68"), ApplicationId = 7, Name = "Comercial" },
        new Role { Id = Guid.Parse("89789f4a-570d-451d-b99b-69127421f1fe"), ApplicationId = 7, Name = "Operaciones" },
        new Role { Id = Guid.Parse("228ee2e2-843e-47cc-98ff-ae78e52340b7"), ApplicationId = 7, Name = "Administrador" },
        new Role { Id = Guid.Parse("8c187a8e-a65a-45a1-a29b-49c99e1b3cff"), ApplicationId = 7, Name = "GRC" },
      ]);
  }
}
