using Finanzauto.Core.Persistence.SqlServer.Configuration.Entities;
using Finanzauto.Core.Persistence.SqlServer.Configuration.Extensions;

namespace Finanzauto.Identity.Api.Models.Settings.Authentication;

public sealed class DomainAuthenticationSettings
{
  public string BaseUrl { get; set; }

  public DomainAuthenticationSettings(string baseUrl)
  {
    BaseUrl = baseUrl;
  }

#pragma warning disable CS8618
  public DomainAuthenticationSettings() {}
#pragma warning restore CS8618

  public static readonly IEnumerable<DbConfigurationSection<Guid>> DefaultSettings = [
    ..ConfigurationSerializationExtensions.Serialize<Guid>(
      new
      {
        BaseUrl = "http://www.qdatacolombia.com/Services/ServiciosApi/ServiceAutenticacionLDAP"
      },
      $"{nameof(DomainAuthenticationSettings)}"
    )
  ];
}
