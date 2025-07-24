using Fz.Identity.Api.Database.Entities;

namespace Fz.Identity.Api.Features.Requests.Dtos;

public sealed record RequestRejectionDto(
  string Reason,
  string RejectedDate,
  string RejectedBy
  )
{
  public static RequestRejectionDto MapFrom(Request request, User user)
    => new(
      request.RejectionReason,
       TimeZoneInfo.ConvertTime((DateTime)request.ProcessedAt, TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time")).ToString("dd/MM/yyyy hh:mm tt"),
       $"{user.Name} {user.Surname}"
      );
}
