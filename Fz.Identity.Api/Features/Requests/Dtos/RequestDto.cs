using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Roles.Dtos;
using Fz.Identity.Api.Features.Users.Dtos;

namespace Fz.Identity.Api.Features.Requests.Dtos;

public sealed record RequestDto(
  int Id,
  string CreatedDate,
  string Application,
  string User,
  string Reason,
  string Status,
  string? RemainingTime
  )
{
  public static RequestDto MapFrom(Request request)
    => new(
        request.Id,
        TimeZoneInfo.ConvertTime(request.CreatedAtUtc, TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time")).ToString("dd/MM/yyyy hh:mm tt"),
        request.Application.Name,
        request.CreatedBy.ToString(),
        request.Reason,
        request.Status.Name,
        RequestDetailDto.GettRemainingTime(request.ExpireAt)
      );
}
