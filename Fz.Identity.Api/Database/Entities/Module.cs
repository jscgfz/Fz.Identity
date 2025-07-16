using Fz.Core.Domain.Primitives;

namespace Fz.Identity.Api.Database.Entities;

public class Module : MasterEntity<int>
{
  public int? ParentId { get; set; }
  public int ApplicationId { get; set; }

  public virtual Module? Parent { get; set; }
  public virtual Application Application{ get; set; }
}
