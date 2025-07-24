using Fz.Identity.Api.Features.Masters.Dtos;
using Claim = Fz.Identity.Api.Database.Entities.Claim;

namespace Fz.Identity.Api.Features.Auth.Dtos;

public sealed record PermissionDto(
  int Id,
  string Name,
  bool Enabled
  ) : MasterDto<int>(Id, Name);
