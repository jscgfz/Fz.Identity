using Finanzauto.Core.Persistence.SqlServer.Abstractions;
using Finanzauto.Core.Persistence.SqlServer.Specifications;
using Finanzauto.Identity.Api.Domain.Entities.Authorization;
using Finanzauto.Identity.Api.Domain.Entities.Claims;
using Finanzauto.Identity.Api.Features.V2.Claims.Dtos;
using Finanzauto.Identity.Api.Features.V2.Claims.Queries.Values;

namespace Finanzauto.Identity.Api.Database.Specifications;

public static class ClaimsSpecifications
{
  public static ISpecification<ApiKeyClaim, string> ByApiKey(Guid id)
    => new SpecificationBuilder<ApiKeyClaim, string>()
      .WithFilter(row => row.ApiKeyId == id)
      .WithInclude($"{nameof(ApiKeyClaim.ClaimValue)}.{nameof(ClaimValue.ClaimAction)}")
      .WithInclude($"{nameof(ApiKeyClaim.ClaimValue)}.{nameof(ClaimValue.ClaimSection)}")
      .WithSelect(row => string.Format("{0}:{1}", row.ClaimValue.ClaimSection.Name, row.ClaimValue.ClaimAction.Name));

  public static ISpecification<RoleClaim, string> ByRoles(params IEnumerable<Guid> roles)
    => new SpecificationBuilder<RoleClaim, string>()
      .WithFilter(row => roles.Contains(row.RoleId))
      .WithInclude($"{nameof(RoleClaim.ClaimValue)}.{nameof(ClaimValue.ClaimAction)}")
      .WithInclude($"{nameof(RoleClaim.ClaimValue)}.{nameof(ClaimValue.ClaimSection)}")
      .WithSelect(row => string.Format("{0}:{1}", row.ClaimValue.ClaimSection.Name, row.ClaimValue.ClaimAction.Name));

  public static ISpecification<ClaimValue, FullClaimDto> ByFilter(ClaimValuesQuery query)
    => new SpecificationBuilder<ClaimValue, FullClaimDto>()
      .WithInclude(row => row.ClaimAction)
      .WithInclude(row => row.ClaimSection)
      .WithSelect(row => new FullClaimDto(
        string.Format("{0}:{1}", row.ClaimSection.Name, row.ClaimAction.Name),
        new ClaimResponseDto(row.ClaimAction.Id, row.ClaimAction.Name, row.ClaimAction.Description),
        new ClaimResponseDto(row.ClaimSection.Id, row.ClaimSection.Name, row.ClaimSection.Description)
      ));
      
}
