namespace Fz.Identity.Api.Models.Files;

public sealed record ExcelFileData(
  Dictionary<string, string> Columns,
  IEnumerable<Dictionary<string, object?>> Body
);
