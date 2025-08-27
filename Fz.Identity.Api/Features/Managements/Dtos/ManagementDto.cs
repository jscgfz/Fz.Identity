using Fz.Core.Domain.Primitives;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Database.Migrations;
using MediatR;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Fz.Identity.Api.Features.Managements.Dtos;

public sealed record ManagementDto(
  string User,
  string Module,
  string Action,
  string Date,
  string Description
  )
{
  public static ManagementDto MapFrom(AuditLog auditLog)
  => new(
       $"{auditLog.User.Name} {auditLog.User.Surname}",
       auditLog.Module,
       auditLog.Action,
       auditLog.CreatedAtUtc.ToString("dd/MM/yyyy hh:mm tt"),
       auditLog.Description
       );
}
