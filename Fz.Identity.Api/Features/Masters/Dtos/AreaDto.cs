namespace Fz.Identity.Api.Features.Masters.Dtos;

public sealed record AreaDto(int Id, string Name) : MasterDto<int>(Id, Name);
