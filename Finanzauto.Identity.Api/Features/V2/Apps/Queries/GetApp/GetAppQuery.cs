using Finanzauto.Core.Result.Extensions;
using Finanzauto.Identity.Api.Features.V2.Apps.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.Apps.Queries.GetApp;

public sealed record GetAppQuery(
  Guid Id
) : IQuery<AppDetailsDto>;