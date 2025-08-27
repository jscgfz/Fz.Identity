using Azure.Core;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Database.Migrations;
using Fz.Identity.Api.Features.Auth.Dtos;
using Fz.Identity.Api.Features.Roles.Commands.AddRole;
using Fz.Identity.Api.Features.Roles.Dtos;
using Fz.Identity.Api.Settings;
using System.Text.Json;
using System.Text.Json.Serialization;
using Request = Fz.Identity.Api.Database.Entities.Request;

namespace Fz.Identity.Api.Features.Requests.Dtos;

public sealed record RequestDetailDto(
  string User,
  string CreatedDate,
  string Status,
  string? RemainingTime,
  string CurrentName,
  string RequestedName,
  string CurrentADName,
  string RequestedADName,
  string AuthorizationFileName,
  string AuthorizationFileId,
  string? Reason,
  IEnumerable<ModuleDto> CurrentModules,
  IEnumerable<ModuleDto> RequestedModules,
  string? ManagementUser,
  string? ManagementDate,
  string? RejectionReason
  )
{
  public static RequestDetailDto MapFrom(Request request, RoleDetailDto role, User user, ActiveDirectoryRole? activeDirectoryRole, User? managementUser)
  => new(
      $"{user.Name} {user.Surname}",
      request.CreatedAtUtc.ToString("dd/MM/yyyy hh:mm tt"),
      request.Status.Name,
      request.StatusId == (int)RequestStatuses.Pending ? GettRemainingTime(request.ExpireAt) : null,
      role.Name,
      GetChanges(request.ChangesJson).Name,
      role.ActiveDirectoryRoleName,
      activeDirectoryRole?.Name,
      request.AuthorizationFileName,
      request.AuthorizationFileId,
      request.Reason,
      role.Modules,
      GetChanges(request.ChangesJson).Modules,
      managementUser != null ? $"{managementUser.Name} {managementUser.Surname}" : null,
      request.ProcessedAt?.ToString("dd/MM/yyyy hh:mm tt"),
      request.RejectionReason
    );

  public static string? GettRemainingTime(DateTime expireDate)
  {
    DateTime currentdate = DateTime.Now;
    if (currentdate > expireDate)
      return null;

    var diff = expireDate - currentdate;

    if (diff.TotalDays >= 1)
    {
      return $"{(int)diff.TotalDays} días";
    }
    else
    {
      return $"{(int)diff.TotalHours} horas";
    }
  }

  public static AddRoleCommand GetChanges(string changesJson)
  {
    var options = new JsonSerializerOptions
    {
      PropertyNameCaseInsensitive = true
    };
    return JsonSerializer.Deserialize<AddRoleCommand>(changesJson, options);
  }
}
