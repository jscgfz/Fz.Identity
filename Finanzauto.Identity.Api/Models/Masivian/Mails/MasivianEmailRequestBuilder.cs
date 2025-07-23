using Finanzauto.Identity.Api.Domain.Enums.Masivian;
using Finanzauto.Identity.Api.Models.Masivian.Mails.Request;
using Finanzauto.Identity.Api.Models.Settings.Masivian;

namespace Finanzauto.Identity.Api.Models.Masivian.Mails;

public sealed class MasivianEmailRequestBuilder
{
  private string? _subject;
  private string? _from;
  private IEnumerable<MasivianRecipientRequest>? _recipients;
  private MasivianTemplateRequest? _template;
  private string? _replyTo;
  private IEnumerable<MasivianParameterRequest>? _parameters;
  private IEnumerable<MasivianAttachmentRequest>? _attachments;
  private Dictionary<string, string>? _metadata;

  public MasivianEmailRequestBuilder() { }

  public MasivianEmailRequestBuilder WithMetadata(Dictionary<string, string> metadata)
  {
    _metadata = metadata;
    return this;
  }

  public MasivianEmailRequestBuilder WithSubject(string subject)
  {
    _subject = subject;
    return this;
  }

  public MasivianEmailRequestBuilder WithFrom(string from)
  {
    _from = from;
    return this;
  }

  public MasivianEmailRequestBuilder WithRecipient(
    string to,
    string? from,
    string? subject,
    string? cellPhone,
    IEnumerable<MasivianParameterRequest>? parameters,
    IEnumerable<MasivianAttachmentRequest>? attachments
  )
  {
    _recipients ??= [];
    _recipients = _recipients.Append(
      new MasivianRecipientRequest(
        to,
        cellPhone,
        from,
        subject,
        parameters,
        attachments
      )
    );

    return this;
  }

  public MasivianEmailRequestBuilder WithRecipient(
    string to
  )
    => WithRecipient(to, null, null, null, null, null);

  public MasivianEmailRequestBuilder WithRecipient(
    string to,
    string? from
  )
    => WithRecipient(to, from, null, null, null, null);

  public MasivianEmailRequestBuilder WithRecipient(
    string to,
    string? from,
    string? subject
  )
    => WithRecipient(to, from, subject, null, null, null);

  public MasivianEmailRequestBuilder WithRecipient(
    string to,
    IEnumerable<MasivianParameterRequest>? parameters
  )
    => WithRecipient(to, null, null, null, parameters, null);

  public MasivianEmailRequestBuilder WithRecipient(
    string to,
    string? from,
    IEnumerable<MasivianParameterRequest>? parameters
  )
    => WithRecipient(to, from, null, null, parameters, null);

  public MasivianEmailRequestBuilder WithRecipient(
    string to,
    string? from,
    string? subject,
    IEnumerable<MasivianParameterRequest>? parameters
  )
    => WithRecipient(to, from, subject, null, parameters, null);

  public MasivianEmailRequestBuilder WithTemplate(MasivianParameterTypes type, string value)
  {
    _template = new(type, value);
    return this;
  }

  public MasivianEmailRequestBuilder WithReplyTo(string replyTo)
  {
    _replyTo = replyTo;
    return this;
  }

  public MasivianEmailRequestBuilder WithParameter(string name, MasivianParameterTypes type, string value)
  {
    _parameters ??= [];
    _parameters = _parameters.Append(new(name, type, value));
    return this;
  }

  public MasivianEmailRequestBuilder WithAttachment(string path, string filename, MasivianAttachmentActions action, string? password)
  {
    _attachments ??= [];
    _attachments = _attachments.Append(new(path, filename, action, password));
    return this;
  }

  public MasivianEmailRequestBuilder WithAttachment(string path, string filename, MasivianAttachmentActions action)
    => WithAttachment(path, filename, action, null);

  public MasivianEmailRequest Build()
    => new(
      _subject ?? throw new NullReferenceException(nameof(_subject)),
      _from ?? throw new NullReferenceException(nameof(_from)),
      _recipients ?? throw new NullReferenceException(nameof(_recipients)),
      _template ?? throw new NullReferenceException(nameof(_template)),
      _replyTo,
      _parameters,
      _attachments,
      _metadata
    );

  public MasivianEmailRequest Build(IConfigurationSection section)
  {
    MasivianEmailTemplateSettings settings = section.Get<MasivianEmailTemplateSettings>()
      ?? throw new NullReferenceException(nameof(MasivianEmailTemplateSettings));

    _from = settings.From;
    _subject = settings.Subject;
    _template = settings.Template;
    return Build();
  }
}
