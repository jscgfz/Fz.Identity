namespace Finanzauto.Identity.Api.Models.Credential.Dtos;

public sealed record CreateCredentialDto(
  string UserName,
  string? Password,
  int LoginTypeId,
  Guid? ApplicationId
);
