using System.Text.RegularExpressions;

namespace Finanzauto.Identity.Api.Domain.Constants;

public static class DomainRegularExpressions
{
  public static Regex PhoneNumber => new("^(\\+?57)?\\d{10}$");
}
