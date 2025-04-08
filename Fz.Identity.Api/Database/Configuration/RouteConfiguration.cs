using Fz.Identity.Api.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Route = Fz.Identity.Api.Database.Entities.Route;

namespace Fz.Identity.Api.Database.Configuration;

public sealed class RouteConfiguration : IEntityTypeConfiguration<Route>
{
  public void Configure(EntityTypeBuilder<Route> builder)
  {

    builder.ToTable("Routes", IdentityContextSchemas.Configuration);
    builder.HasIndex(row => new { row.ApplitionId, row.Name }).IsUnique();
    builder.HasOne(row => row.Application)
      .WithMany(row => row.Routes)
      .HasForeignKey(row => row.ApplitionId)
      .OnDelete(DeleteBehavior.NoAction);
    builder.HasOne(row => row.Parent)
      .WithMany(row => row.Children)
      .HasForeignKey(row => row.ParentId)
      .OnDelete(DeleteBehavior.NoAction);

    builder
      .HasData([
        new() { Id = 1, ApplitionId = 7, Name = "Tus Solicitudes", UrlImg = string.Empty, Path = "/your-requests", ExcludeNav = true, Component = "your-requests" },
        new() { Id = 2, ApplitionId = 7, Name = "Inicio", UrlImg = string.Empty, Path = "/", ExcludeNav = true, Component = "home" },
        new() { Id = 3, ApplitionId = 7, Name = "Detalle del cliente", UrlImg = string.Empty, Path = "/your-requests/request-client-detail/:requestId", ExcludeNav = true, Component = "request-client-detail" },
        new() { Id = 4, ApplitionId = 7, Name = "Radicación de crédito", UrlImg = string.Empty, Path = "/credit-filing", ExcludeNav = true, Component = "credit-filing" },
      ]);
  }
}
