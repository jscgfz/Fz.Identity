using Fz.Core.Persistence.Abstractions;
using Fz.Core.Persistence.Common;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Managements.Dtos;
using Fz.Identity.Api.Features.Managements.Queries;

namespace Fz.Identity.Api.Features.Managements;

public sealed class ManagementSpecifications
{
  public static ISpecification<AuditLog, ManagementDto> ByManagementsQuery(ManagementsQuery query)
    => new Specification<AuditLog, ManagementDto>()
    .WithFilter(row => (!query.DateFrom.HasValue || row.CreatedAtUtc.Date >= query.DateFrom.Value.Date) && (!query.DateTo.HasValue || row.CreatedAtUtc.Date <= query.DateTo.Value.Date)) 
    .WithAndFilter(row =>
    string.IsNullOrEmpty(query.User) || row.User.Name.ToLower().Contains(query.User.ToLower()) || row.User.Surname.ToLower().Contains(query.User.ToLower()))
    .WithInclude(row => row.User)
    .WithSelect(row => ManagementDto.MapFrom(row));
}
 