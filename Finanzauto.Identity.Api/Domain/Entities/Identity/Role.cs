using Finanzauto.Core.Domain.Primitives;
using Finanzauto.Identity.Api.Abstractions.Persistence;
using Finanzauto.Identity.Api.Domain.Entities.Authentication;
using Finanzauto.Identity.Api.Domain.Entities.Authorization;
using Finanzauto.Identity.Api.Domain.Entities.Configuration;

namespace Finanzauto.Identity.Api.Domain.Entities.Identity;

public class Role : MasterEntity<Guid>, IRootEntity
{
  public Guid AppId { get; set; }
  public string? DomainName { get; set; }
  public bool IsRoot { get; set; }

  public virtual App App { get; set; } = default!;
  public virtual ICollection<UserRole> AsignedUsers { get; set; } = default!;
  public virtual ICollection<RoleClaim> Claims { get; set; } = default!;
  public virtual ICollection<RoleRoute> Routes { get; set; } = default!;

  public Role(Guid appId, string? domainName, bool isRoot)
  {
    AppId = appId;
    DomainName = domainName;
    IsRoot = isRoot;
  }

  public Role() { }
}
