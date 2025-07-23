namespace Finanzauto.Identity.Api.Models.Authentication.Dtos;

public sealed record CredentialV1Dto(
  string UserName,
  string Password
);
