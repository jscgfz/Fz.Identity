namespace Fz.Identity.Api.Features.Auth.Dtos;

public sealed record SubmoduleDto(
  int Id,
  string Name,
  IEnumerable<PermissionDto>? Permissions
  )
{
}
