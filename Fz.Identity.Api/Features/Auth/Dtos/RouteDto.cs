using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Masters.Dtos;

namespace Fz.Identity.Api.Features.Auth.Dtos;

public sealed record RouteDto(
  int Id,
  string Name,
  string UrlImg,
  string Path,
  int Order,
  bool ExcludeNav,
  string Component,
  RouteAccessDto Access,
  IEnumerable<RouteDto>? ChildModules
) : MasterDto<int>(Id, Name)
{
  public static IEnumerable<RouteDto> MapFrom(IEnumerable<RoleRoute> routes, int? parentId)
    => routes
      .Where(route => route.Route.ParentId == parentId)
      .Select(route => new RouteDto(
        route.Route.Id,
        route.Route.Name,
        route.Route.UrlImg,
        route.Route.Path,
        route.Route.Order,
        route.Route.ExcludeNav,
        route.Route.Component,
        new RouteAccessDto(
          route.ReadClaimId.HasValue,
          route.CreateClaimId.HasValue,
          route.EditClaimId.HasValue,
          route.StatusClaimId.HasValue,
          route.DownloadClaimId.HasValue,
          route.SpecialConditionClaimId.HasValue
        ),
        routes.Any(r => r.Route.ParentId == route.Route.Id) ? MapFrom(routes, route.Route.Id) : null
      ));
}
