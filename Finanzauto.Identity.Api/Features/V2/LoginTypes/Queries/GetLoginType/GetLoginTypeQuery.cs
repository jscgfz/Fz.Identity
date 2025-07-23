using Finanzauto.Core.Result.Extensions;
using Finanzauto.Identity.Api.Features.V2.LoginTypes.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.LoginTypes.Queries.GetLoginType;

public sealed record GetLoginTypeQuery(
  int Id
) : IQuery<LoginTypeDetailDto>;
