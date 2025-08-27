namespace Fz.Identity.Api.Features.Masters.Dtos;

public sealed record RoleMasterDto(Guid Id, string Name) : MasterDto<Guid>(Id, Name);
