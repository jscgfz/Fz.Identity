using Azure.Core;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Database.Migrations;
using Fz.Identity.Api.Features.Auth.Dtos;
using Fz.Identity.Api.Features.Roles.Commands.AddRole;
using Fz.Identity.Api.Features.Roles.Dtos;
using System.Text.Json;
using System.Text.Json.Serialization;
using Request = Fz.Identity.Api.Database.Entities.Request;

namespace Fz.Identity.Api.Features.Requests.Dtos;

public sealed record RequestDetailDto(
  string User,
  string CreatedDate,
  string Status,
  string RemainingTime,
  string CurrentName,
  string RequestedName,
  string CurrentADName,
  string RequestedADName,
  string AuthorizationFileName,
  string AuthorizationFileId,
  string? Reason,
  IEnumerable<ModuleDto> CurrentModules,
  IEnumerable<ModuleDto> RequestedModules
  )
{
  public static RequestDetailDto MapFrom(Request request, RoleDetailDto role)
  => new(
      request.CreatedBy.ToString(),
      TimeZoneInfo.ConvertTime(request.CreatedAtUtc, TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time")).ToString("dd/MM/yyyy hh:mm tt"),
      request.Status.Name,
      GettRemainingTime(request.CreatedAtUtc, request.ExpireAt),
      role.Name,
      GetChanges(request.ChangesJson).Name,
      role.ActiveDirectoryName,
      GetChanges(request.ChangesJson).ActiveDirectoryRole,
      request.AuthorizationFileName,
      request.AuthorizationFileId,
      request.Reason,
      role.Modules,
      GetChanges(request.ChangesJson).Modules
    );

  public static string? GettRemainingTime(DateTime createdDate, DateTime expireDate)
  {
    if (expireDate > createdDate)
      return null;

    var diff = createdDate - expireDate;

    if (diff.TotalDays >= 1)
    {
      return $"{(int)diff.TotalDays} días";
    }
    else
    {
      return $"{(int)diff.TotalHours} horas";
    }
  }

  private static AddRoleCommand GetChanges(string changesJson)
  {
    var options = new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true
    };
    return JsonSerializer.Deserialize<AddRoleCommand>(changesJson, options);
  }
}
