using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Text.Json;

namespace Finanzauto.Identity.Api.Database.Conventions;

public sealed class SeedContextConvention(IServiceProvider provider, params IEnumerable<string> paths) : IModelFinalizingConvention
{
  private readonly IWebHostEnvironment _host = provider.GetRequiredService<IWebHostEnvironment>();
  private readonly IEnumerable<string> _paths = paths;
  private readonly ILogger<SeedContextConvention> _logger = provider.GetRequiredService<ILogger<SeedContextConvention>>();

  public void ProcessModelFinalizing(IConventionModelBuilder modelBuilder, IConventionContext<IConventionModelBuilder> context)
  {
    
    try
    {
      string json = ReadJson();
      if (string.IsNullOrWhiteSpace(json))
        return;
      
      JsonElement data = JsonSerializer.Deserialize<JsonElement>(json, JsonSerializerOptions.Web);
      if (data.ValueKind != JsonValueKind.Array)
      {
        _logger.LogWarning("Seed file does not contain a valid JSON object.");
        return;
      }

      foreach(var table in modelBuilder
        .Metadata
        .GetEntityTypes()
        .Join(
          data.EnumerateArray(),
          entity => $"{entity.GetSchema() ?? string.Empty}:{entity.GetTableName() ?? string.Empty}",
          el =>
          {
            string schema = el.TryGetProperty("schema", out JsonElement ps) ? ps.GetString()! : string.Empty;
            string table = el.TryGetProperty("name", out JsonElement pt) ? pt.GetString()! : string.Empty;
            return $"{schema}:{table}";
          },
          (entity, el) => new
          {
            Entity = entity,
            Element = el.TryGetProperty("data", out JsonElement dataElement) ? dataElement : default
          }
        ))
      {
        Type tableType = table.Entity.ClrType;
        if (tableType == null || table.Element.ValueKind != JsonValueKind.Array)
        {
          _logger.LogWarning("Entity {Entity} does not have a valid data array in the seed file.", $"{table.Entity.GetSchema() ?? string.Empty}:{table.Entity.GetTableName() ?? string.Empty}");
          continue;
        }
        object? tableData = table.Element.Deserialize(typeof(IEnumerable<>).MakeGenericType(tableType), JsonSerializerOptions.Web);
        if (tableData == null)
        {
          _logger.LogWarning("Entity {Entity} data is null or empty in the seed file.", $"{table.Entity.GetSchema() ?? string.Empty}:{table.Entity.GetTableName() ?? string.Empty}");
          continue;
        }
        if (tableData is IEnumerable<object> dataList && dataList.Any())
        {
          ((IMutableEntityType)table.Entity).AddData(dataList);
          _logger.LogInformation("Seeded {Count} records for entity {Entity}.", dataList.Count(), $"{table.Entity.GetSchema() ?? string.Empty}:{table.Entity.GetTableName() ?? string.Empty}");
        }
        else
        {
          _logger.LogWarning("Entity {Entity} does not have valid data to seed.", $"{table.Entity.GetSchema() ?? string.Empty}:{table.Entity.GetTableName() ?? string.Empty}");
        }
      }
      _logger.LogInformation("Seed data loaded");
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "Error loading seed data");
    }
  }

  private string ReadJson()
  {
    FileInfo fileInfo = new(Path.Combine([_host.ContentRootPath, .. _paths]));
    if (!fileInfo.Exists)
    {
      _logger.LogWarning("Seed file {File} does not exist.", fileInfo.FullName);
      return string.Empty;
    }
    using StreamReader reader = new(fileInfo.OpenRead());
    string json = reader.ReadToEnd();
    if (string.IsNullOrWhiteSpace(json))
      _logger.LogWarning("Seed file {File} is empty.", fileInfo.FullName);
    
    return json;
  }
}
