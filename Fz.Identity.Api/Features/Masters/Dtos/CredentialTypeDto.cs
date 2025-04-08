namespace Fz.Identity.Api.Features.Masters.Dtos;

public sealed record CredentialTypeDto(int Id, string Name, string Description) : MasterDto<int>(Id, Name);
