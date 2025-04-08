namespace Fz.Identity.Api.Features.Masters.Dtos;

public sealed record ApplicationDto(int Id, string Name) : MasterDto<int>(Id, Name);
