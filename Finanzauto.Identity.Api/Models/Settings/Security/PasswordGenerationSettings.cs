using Finanzauto.Core.Persistence.SqlServer.Configuration.Entities;
using Finanzauto.Core.Persistence.SqlServer.Configuration.Extensions;

namespace Finanzauto.Identity.Api.Models.Settings.Security;

public sealed class PasswordGenerationSettings
{
  public int MinimunLength { get; set; }
  public bool RequiresUpperCase { get; set; }
  public bool RequiresLowerCase { get; set; }
  public bool RequiresNumbers { get; set; }
  public bool RequiresSpecialCharacters { get; set; }
  public IEnumerable<char> AlloWedCharacters { get; set; }

  public PasswordGenerationSettings(
    int minimunLength,
    bool requiresUpperCase,
    bool requiresLowerCase,
    bool requiresNumbers,
    bool requiresSpecialCharacters,
    IEnumerable<char> alloWedCharacters
  )
  {
    MinimunLength = minimunLength;
    RequiresUpperCase = requiresUpperCase;
    RequiresLowerCase = requiresLowerCase;
    RequiresNumbers = requiresNumbers;
    RequiresSpecialCharacters = requiresSpecialCharacters;
    AlloWedCharacters = alloWedCharacters;
  }

#pragma warning disable CS8618
  public PasswordGenerationSettings() { }
#pragma warning restore CS8618

  public static readonly IEnumerable<DbConfigurationSection<Guid>> DefaultSettings = ConfigurationSerializationExtensions.Serialize<Guid>(
    new PasswordGenerationSettings()
    {
      MinimunLength = 10,
      RequiresUpperCase = true,
      RequiresLowerCase = true,
      RequiresNumbers = true,
      AlloWedCharacters = "!#$%&/()=?¡*+-_.:,;{}[]~\\"
    },
    nameof(PasswordGenerationSettings)
  );
}
