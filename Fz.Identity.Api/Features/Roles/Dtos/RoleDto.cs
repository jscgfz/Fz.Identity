using Fz.Identity.Api.Features.Masters.Dtos;

namespace Fz.Identity.Api.Features.Roles.Dtos;

public sealed record RoleDto(Guid Id, string Name, int? ApplicationId) : MasterDto<Guid>(Id, Name);
