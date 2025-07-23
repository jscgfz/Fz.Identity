using Finanzauto.Identity.Api.Domain.Enums.Masivian;

namespace Finanzauto.Identity.Api.Models.Masivian.Mails.Request;

public sealed record MasivianParameterRequest(
  string Name,
  MasivianParameterTypes Type,
  string Value
);