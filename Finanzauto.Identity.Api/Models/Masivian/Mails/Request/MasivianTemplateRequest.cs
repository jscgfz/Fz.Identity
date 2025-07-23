using Finanzauto.Identity.Api.Domain.Enums.Masivian;

namespace Finanzauto.Identity.Api.Models.Masivian.Mails.Request;

public sealed record MasivianTemplateRequest(
  MasivianParameterTypes Type,
  string Value
);
