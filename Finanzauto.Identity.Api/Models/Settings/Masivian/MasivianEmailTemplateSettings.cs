using Finanzauto.Core.Persistence.SqlServer.Configuration.Entities;
using Finanzauto.Core.Persistence.SqlServer.Configuration.Extensions;
using Finanzauto.Identity.Api.Domain.Constants;
using Finanzauto.Identity.Api.Domain.Enums.Masivian;
using Finanzauto.Identity.Api.Models.Masivian.Mails.Request;

namespace Finanzauto.Identity.Api.Models.Settings.Masivian;

public sealed class MasivianEmailTemplateSettings
{
  public string Subject { get; set; }
  public string From { get; set; }
  public MasivianTemplateRequest Template { get; set; }

  public MasivianEmailTemplateSettings(string subject, string from, MasivianTemplateRequest template)
  {
    Subject = subject;
    From = from;
    Template = template;
  }

#pragma warning disable CS8618
  public MasivianEmailTemplateSettings()
#pragma warning restore CS8618
  {
  }

  public static readonly IEnumerable<DbConfigurationSection<Guid>> DefaultSettings = [
    ..ConfigurationSerializationExtensions.Serialize<Guid>(
      new
      {
        Subject = "[Identity Services] Contraseña de un solo uso - OTP",
        From = "identity.helpdesk@finanzauto.com.co",
        Template = new {
          Type = ((int)MasivianParameterTypes.TextHtml),
          Value = "<html lang=\"es\"><head><meta charset=\"UTF-8\"><title>Código OTP</title></head><body style=\"font-family: Arial, sans-serif; background-color: #F9F9F9; padding: 20px; color: #333;\"><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td align=\"center\"><table width=\"600\" cellpadding=\"20\" cellspacing=\"0\" border=\"0\" style=\"background-color: #FFFFFF; border: 1px solid #DDDDDD;\"><tr><td align=\"center\"><h2 style=\"color: #333333;\">Tu código OTP</h2><p style=\"font-size: 16px;\">Usa el siguiente código para completar tu verificación:</p><p style=\"font-size: 28px; font-weight: bold; letter-spacing: 4px; margin: 20px 0; color: #000000;\">[otp]</p><p style=\"font-size: 14px; color: #666666;\">Este código es válido por solo unos minutos. No lo compartas con nadie.</p><br><p style=\"font-size: 14px;\">Si no solicitaste este código, puedes ignorar este mensaje.</p><br><p style=\"font-size: 12px; color: #999999;\">Gracias,<br>El equipo del Garaje</p></td></tr></table></td></tr></table></body></html>"
        }
      },
      $"{nameof(MasivianEmailTemplateSettings)}:{MasivianTemplateKeys.Otp}"
    ),
    ..ConfigurationSerializationExtensions.Serialize<Guid>(
      new
      {
        Subject = "[Identity Services] Recuperación de contraseña",
        From = "identity.helpdesk@finanzauto.com.co",
        Template = new {
          Type = ((int)MasivianParameterTypes.TextHtml),
          Value = "<html lang=\"es\"><head><meta charset=\"UTF-8\"><title>Código OTP</title></head><body style=\"font-family: Arial, sans-serif; background-color: #F9F9F9; padding: 20px; color: #333;\"><table width=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr><td align=\"center\"><table width=\"600\" cellpadding=\"20\" cellspacing=\"0\" border=\"0\" style=\"background-color: #FFFFFF; border: 1px solid #DDDDDD;\"><tr><td align=\"center\"><h2 style=\"color: #333333;\">Tu código OTP</h2><p style=\"font-size: 16px;\">Usa el siguiente código para completar tu verificación:</p><p style=\"font-size: 28px; font-weight: bold; letter-spacing: 4px; margin: 20px 0; color: #000000;\">[otp]</p><p style=\"font-size: 14px; color: #666666;\">Este código es válido por solo unos minutos. No lo compartas con nadie.</p><br><p style=\"font-size: 14px;\">Si no solicitaste este código, puedes ignorar este mensaje.</p><br><p style=\"font-size: 12px; color: #999999;\">Gracias,<br>El equipo del Garaje</p></td></tr></table></td></tr></table></body></html>"
        }
      },
      $"{nameof(MasivianEmailTemplateSettings)}:{MasivianTemplateKeys.RecoveryPasword}"
    ),
  ];
}
