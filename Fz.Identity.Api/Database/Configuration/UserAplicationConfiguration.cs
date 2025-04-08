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
        new() { UserId = Guid.Parse("aa79dc95-724d-4eef-9744-7debd5d322a3"), ApplicationId = 3 },
        new() { UserId = Guid.Parse("b1c48de3-2e15-4f06-a3c4-be4775936220"), ApplicationId = 3 },
        new() { UserId = Guid.Parse("f291a98b-36da-4651-bdb5-c7f60e20d802"), ApplicationId = 3 },
        new() { UserId = Guid.Parse("56313c74-d9fd-44d3-9668-c8ff502c556d"), ApplicationId = 3 },
        new() { UserId = Guid.Parse("d6b042e8-2476-447e-80b4-a8c2c7b32ace"), ApplicationId = 3 },
        new() { UserId = Guid.Parse("f015f137-5352-48e9-8120-609639131906"), ApplicationId = 3 },
        new() { UserId = Guid.Parse("0b9e3e25-3c8a-483a-a95c-ddf8b9969f40"), ApplicationId = 3 },
        new() { UserId = Guid.Parse("72dddef4-4900-4aaa-9c40-3c24aee6b4d7"), ApplicationId = 3 }
      ]);
  }
}
