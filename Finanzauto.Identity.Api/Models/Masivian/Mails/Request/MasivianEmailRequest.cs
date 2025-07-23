namespace Finanzauto.Identity.Api.Models.Masivian.Mails.Request;

public sealed record MasivianEmailRequest(
  string Subject,
  string From,
  IEnumerable<MasivianRecipientRequest> Recipients,
  MasivianTemplateRequest Template,
  string? ReplyTo = null,
  IEnumerable<MasivianParameterRequest>? Parameters = null,
  IEnumerable<MasivianAttachmentRequest>? Attachments = null,
  Dictionary<string, string>? Metadata = null
);
