using Fz.Identity.Api.Constants;
using Fz.Identity.Api.Database.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Fz.Identity.Api.Database.Configuration;

public sealed class ClaimTypeConfiguration : IEntityTypeConfiguration<ClaimType>
{
  public void Configure(EntityTypeBuilder<ClaimType> builder)
  {
    builder.ToTable("ClaimTypes", IdentityContextSchemas.Configuration);
    builder.HasData([
      new ClaimType { Id = 1, Name = "Permission", Description = "Claim para el acceso a un permiso especifico de la aplicación" },
    ]);
  }
}
