using Finanzauto.Identity.Api.Domain.Enums.Masivian;

namespace Finanzauto.Identity.Api.Models.Masivian.Mails.Request;

public sealed record MasivianAttachmentRequest(
  string Path,
  string FileName,
  MasivianAttachmentActions Action,
  string? Password = null
);
