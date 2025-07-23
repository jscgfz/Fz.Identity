using Finanzauto.Core.Persistence.SqlServer.Configuration.Entities;
using Finanzauto.Core.Persistence.SqlServer.Configuration.Extensions;

namespace Finanzauto.Identity.Api.Models.Settings.Security;

public sealed class OtpSettings
{
  public string AlloweCharacters { get; set; }
  public TimeSpan OtpExpiration { get; set; }
  public int OtpLength { get; set; }

  public OtpSettings(string alloweCharacters, TimeSpan otpExpiration, int otpLength)
  {
    AlloweCharacters = alloweCharacters;
    OtpExpiration = otpExpiration;
    OtpLength = otpLength;
  }

#pragma warning disable CS8618
  public OtpSettings() { }
#pragma warning restore CS8618

  public static readonly IEnumerable<DbConfigurationSection<Guid>> DefaultSettings = ConfigurationSerializationExtensions
    .Serialize<Guid>(
      new OtpSettings(
        "0123456789ABCDEFGHIJKLMNOPQRSTUVXYZ",
        TimeSpan.FromMinutes(10), 8
      ),
      nameof(OtpSettings)
    );
}
