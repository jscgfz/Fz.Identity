namespace Finanzauto.Identity.Api.Models.Masivian.Mails.Request;

public sealed record MasivianRecipientRequest(
  string To,
  string? Cellphone = null,
  string? From = null,
  string? Subject = null,
  IEnumerable<MasivianParameterRequest>? Parameters = null,
  IEnumerable<MasivianAttachmentRequest>? Attachments = null
);
