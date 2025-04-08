namespace Fz.Identity.Api.Features.Auth.Dtos;

public sealed record RouteAccessDto(
  bool Read,
  bool Create,
  bool Edit,
  bool Status,
  bool Download,
  bool SpecialConditions
);
