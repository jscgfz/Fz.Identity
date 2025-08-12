using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Roles.Dtos;
using Fz.Identity.Api.Features.Users.Dtos;

namespace Fz.Identity.Api.Features.Requests.Dtos;

public sealed class RequestDto
{
  public int Id { get; set; }
  public string CreatedDate { get; set; }
  public string Application { get; set; }
  public string? User { get; set; }
  public string Reason { get; set; }
  public string Status { get; set; }
  string? RemainingTime { get; set; }
  public Guid UserId { get; set; }

  public RequestDto(int id, string createdDate, string application, string? user, string reason, string status, string? remainingTime, Guid userId)
  {
    Id = id;
    CreatedDate = createdDate;
    Application = application;
    User = user;
    Reason = reason;
    Status = status;
    RemainingTime = remainingTime;
    UserId = userId;
  }

  public static RequestDto MapFrom(Request request)
    => new(
        request.Id,
        TimeZoneInfo.ConvertTime(request.CreatedAtUtc, TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time")).ToString("dd/MM/yyyy hh:mm tt"),
        request.Application.Name,
        null,
        request.Reason,
        request.Status.Name,
        RequestDetailDto.GettRemainingTime(request.ExpireAt),
        request.CreatedBy
      );
}
