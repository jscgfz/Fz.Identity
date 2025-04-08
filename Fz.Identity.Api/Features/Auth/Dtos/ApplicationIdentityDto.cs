using Fz.Identity.Api.Features.Masters.Dtos;
using Fz.Identity.Api.Features.Roles.Dtos;

namespace Fz.Identity.Api.Features.Auth.Dtos;

public sealed record ApplicationIdentityDto(int Id, string Name, IEnumerable<RoleDto>? Roles) : MasterDto<int>(Id, Name);
