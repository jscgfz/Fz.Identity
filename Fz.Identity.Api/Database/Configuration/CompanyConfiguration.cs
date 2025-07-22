using Fz.Identity.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fz.Identity.Api.Database.Configuration;

public sealed class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
  public void Configure(EntityTypeBuilder<Company> builder)
  {
    builder.ToTable("Companies");
    builder.HasData([
      new Company{ Id = 1,  Name = "Finanzauto", Description = string.Empty },
      new Company{ Id = 2,  Name = "Promotec", Description = string.Empty },
      new Company{ Id = 3,  Name = "Asisya", Description = string.Empty },
      ]);
  }
}
