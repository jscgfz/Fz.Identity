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
  {
    var action = GetAction(auditLog.Action);
    var module = GetModule(auditLog.Endpoint);
    var description = GetDescription(action, module, auditLog.Payload);
    return new ManagementDto(
       auditLog.User.Name,
        module,
        action,
       TimeZoneInfo.ConvertTime(auditLog.CreatedAtUtc, TimeZoneInfo.FindSystemTimeZoneById("SA Pacific Standard Time")).ToString("dd/MM/yyyy hh:mm tt"),
       description
       );
  }

  public static string GetAction(string action)
  {
    if (action.StartsWith("POST", StringComparison.OrdinalIgnoreCase)) return "Crear";
    if (action.StartsWith("PUT", StringComparison.OrdinalIgnoreCase)) return "Editar";
    if (action.StartsWith("DELETE", StringComparison.OrdinalIgnoreCase)) return "Eliminar";
    return "Acción";
  }

  public static string GetModule(string path)
  {
    var match = Regex.Match(path, @"api/v\d+/(.*?)(/|$)");
    var rawModulo = match.Success ? match.Groups[1].Value : "Desconocido";

    return rawModulo.ToLower() switch
    {
      "users" => "Usuarios",
      "roles" => "Roles",
      _ => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(rawModulo)
    };
  }

  private static string GetDescription(string action, string module, string? payload)
  {

    string? entityValue = GetEntityValue(module, payload);

    return action switch
    {
      "Crear" => $"Creación de {module.ToLower().TrimEnd('s')} {entityValue}",
      "Editar" => $"Edición de {module.ToLower().TrimEnd('s')} {entityValue}",
      "Eliminar" => $"Eliminación de {module.ToLower().TrimEnd('s')} {entityValue}",
      _ => $"{action} sobre {module}"
    };
  }

  private static string? GetEntityValue(string module, string? payload)
  {
    if (string.IsNullOrEmpty(payload)) return null;

    try
    {
      using var entity = JsonDocument.Parse(payload);
      
        return module switch
      {
        "Usuarios" => GetPropertyValue(entity.RootElement, "name"),
        "Roles" => GetPropertyValue(entity.RootElement, "name"),
        _ => GetPropertyValue(entity.RootElement, "name")
      };
    }
    catch
    {
      return null;
    }
  }

  private static  string? GetPropertyValue(JsonElement payload, string key)
  {
    if (payload.TryGetProperty(key, out var value) && value.ValueKind == JsonValueKind.String)
      return value.GetString();
    return null;
  }
}
