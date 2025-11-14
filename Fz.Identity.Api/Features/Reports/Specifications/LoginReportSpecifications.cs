using Fz.Core.Persistence.Abstractions;
using Fz.Core.Persistence.Common;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Reports.Dtos;
using Fz.Identity.Api.Features.Reports.Queries.FullLoginReport;
using Fz.Identity.Api.Features.Reports.Queries.ResumeLoginReport;

namespace Fz.Identity.Api.Features.Reports.Specifications;

public static class LoginReportSpecifications
{
  public static ISpecification<LoginLog, LoginLogDto> ByFilter(FullLoginReportQuery query)
    => new Specification<LoginLog, LoginLogDto>()
      .WithInclude(row => row.UserApplication.User)
      .WithInclude(row => row.UserApplication.Application)
      .WithFilter(row => !query.StartDate.HasValue || query.StartDate.Value <= row.CreatedAtUtc)
      .WithAndFilter(row => !query.EndDate.HasValue || query.EndDate.Value >= row.CreatedAtUtc)
      .WithAndFilter(row => !query.ApplicationId.HasValue || query.ApplicationId.Value == row.ApplicationId)
      .WithAndFilter(row => !query.UserId.HasValue || query.UserId.Value == row.UserId)
      .WithSelect(row => new LoginLogDto(
        row.UserApplication.UserId,
        $"{row.UserApplication.User.Name} {row.UserApplication.User.Surname}",
        row.UserApplication.ApplicationId,
        row.UserApplication.Application.Name,
        row.Location,
        row.ClaimedAtUtc,
        row.LastTransactionAtUtc
      ));

  public static ISpecification<LoginLog, LoginLogDto> ByFilter(ResumeLoginReportQuery query)
    => new Specification<LoginLog, LoginLogDto>()
      .WithInclude(row => row.UserApplication.User)
      .WithInclude(row => row.UserApplication.Application)
      .WithFilter(row => !query.StartDate.HasValue || query.StartDate.Value <= row.CreatedAtUtc)
      .WithAndFilter(row => !query.EndDate.HasValue || query.EndDate.Value >= row.CreatedAtUtc)
      .WithAndFilter(row => !query.ApplicationId.HasValue || query.ApplicationId.Value == row.ApplicationId)
      .WithAndFilter(row => !query.UserId.HasValue || query.UserId.Value == row.UserId)
      .WithSelect(row => new LoginLogDto(
        row.UserApplication.UserId,
        $"{row.UserApplication.User.Name} {row.UserApplication.User.Surname}",
        row.UserApplication.ApplicationId,
        row.UserApplication.Application.Name,
        row.Location,
        row.ClaimedAtUtc,
        row.LastTransactionAtUtc
      ));
}
