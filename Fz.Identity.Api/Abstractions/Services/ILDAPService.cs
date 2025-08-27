using Fz.Core.Result;
using Fz.Identity.Api.Models.LDAP.Response;

namespace Fz.Identity.Api.Abstractions.Services;

public interface ILDAPService
{
  Task<Result<GetDetailUserResponse>> GetDetailUSer(string userName, string app);
  Task<GetRolesResponse> GetRolesByApp(string alias);
}
