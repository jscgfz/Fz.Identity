namespace Fz.Identity.Api.Features.Auth.Dtos;

public sealed record SubmoduleDto(
  string Name,
  IEnumerable<PermissionDto>? Permissions
  )
{
}
