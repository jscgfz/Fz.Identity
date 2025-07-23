namespace Finanzauto.Identity.Api.Models.Authentication.Dtos;

public sealed record LoginV1Command(
  int ApplicationId,
  CredentialV1Dto Credentials
);
