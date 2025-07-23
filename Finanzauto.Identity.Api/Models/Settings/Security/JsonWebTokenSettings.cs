using Finanzauto.Core.Persistence.SqlServer.Configuration.Entities;
using Finanzauto.Core.Persistence.SqlServer.Configuration.Extensions;

namespace Finanzauto.Identity.Api.Models.Settings.Security;

public class JsonWebTokenSettings
{
  public TimeSpan TokenExpirationTime { get; set; }
  public TimeSpan RefreshTokenExpirationTime { get; set; }

  public JsonWebTokenSettings(TimeSpan tokenExpirationTime, TimeSpan refreshTokenExpirationTime)
  {
    TokenExpirationTime = tokenExpirationTime;
    RefreshTokenExpirationTime = refreshTokenExpirationTime;
  }

  public JsonWebTokenSettings() { }

  public static readonly IEnumerable<DbConfigurationSection<Guid>> DefaultSettings = ConfigurationSerializationExtensions
    .Serialize<Guid>(
      new JsonWebTokenSettings(
        TimeSpan.FromHours(1),
        TimeSpan.FromHours(3)
      ),
      nameof(JsonWebTokenSettings)
    );
}
