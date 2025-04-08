using Fz.Core.Persistence.Abstractions;

namespace Fz.Identity.Api.Abstractions.Persistence;

public interface IIdentityContextControlFieldsManager : IContextControlFieldsManager<Guid>
{
  int? ApplicationId { get; }
  IEnumerable<Guid> RoleIds { get; }
}
