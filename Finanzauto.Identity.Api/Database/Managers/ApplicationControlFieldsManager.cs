using Finanzauto.Core.Persistence.SqlServer;

namespace Finanzauto.Identity.Api.Database.Managers;

public sealed class ApplicationControlFieldsManager(IServiceProvider provider) : BaseContextControlFieldsManager<Guid>(provider)
{
  public override Guid CurrentUserId
  {
    get
    {
      try
      {
        return base.CurrentUserId;
      }
      catch
      {
        return Guid.Empty;
      }
    }
  }
}
