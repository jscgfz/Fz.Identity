using Finanzauto.Core.Result.Extensions;
using Finanzauto.Identity.Api.Features.V2.LoginTypes.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.LoginTypes.Queries.GetLoginTypes;

public sealed record GetLoginTypesQuery : IQuery<IEnumerable<LoginTypeOptionDto>>;
