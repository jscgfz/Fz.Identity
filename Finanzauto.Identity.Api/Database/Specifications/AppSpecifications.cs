using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Persistence.SqlServer.Specifications;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;
using Finanzauto.Identity.Api.Features.V2.Apps.Dtos;
using Finanzauto.Identity.Api.Features.V2.Apps.Queries.GetApp;
using Finanzauto.Identity.Api.Features.V2.Apps.Queries.GetApps;

namespace Finanzauto.Identity.Api.Database.Specifications;

public static class AppSpecifications
{
  public static ISpecification<App, AppDetailsDto> ByFilter(GetAppsQuery query)
    => new SpecificationBuilder<App, AppDetailsDto>()
      .WithInclude(row => row.Safety)
      .WithFilter(row => string.IsNullOrWhiteSpace(query.Filter))
      .WithOrFilter(row => row.ApplicationName.Contains(query.Filter!))
      .WithOrFilter(row => !string.IsNullOrWhiteSpace(row.Description) && row.Description.Contains(query.Filter!))
      .WithOrFilter(row => row.Prefix.Contains(query.Filter!))
      .WithOrFilter(row => row.Id.ToString().Contains(query.Filter!))
      .WithSelect(row => new AppDetailsDto(
        row.Id,
        row.ApplicationName,
        row.Description,
        row.MultiDomainEnabled,
        row.RootApplicationEnabled,
        row.TwoFactorEnabled,
        new AppSecurityDetailsDto(
          row.Prefix,
          row.DomainName,
          null,
          row.Safety.ExpirationTime,
          row.Safety.RefreshExpirationTime
        )
      ));

  public static ISpecification<App, AppDetailsDto> ByFilter(GetAppQuery query)
    => new SpecificationBuilder<App, AppDetailsDto>()
      .WithInclude(row => row.Safety)
      .WithFilter(row => row.Id == query.Id)
      .WithSelect(row => new AppDetailsDto(
        row.Id,
        row.ApplicationName,
        row.Description,
        row.MultiDomainEnabled,
        row.RootApplicationEnabled,
        row.TwoFactorEnabled,
        new AppSecurityDetailsDto(
          row.Prefix,
          row.DomainName,
          null,
          row.Safety.ExpirationTime,
          row.Safety.RefreshExpirationTime
        )
      ));
}
