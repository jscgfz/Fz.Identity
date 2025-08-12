using Fz.Identity.Api.Features.Masters.Dtos;

namespace Fz.Identity.Api.Features.Roles.Dtos;

public sealed record ActiveDirectoryRoleDto(Guid Id, string Name) : MasterDto<Guid>(Id, Name);
