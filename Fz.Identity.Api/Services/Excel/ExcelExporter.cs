using ClosedXML.Excel;
using Fz.Identity.Api.Models.Files;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Fz.Identity.Api.Services.Excel;

public static class ExcelExporter
{
  public static byte[] ExportToExcel(ExcelFileData data, string sheetName)
  {
    using var workbook = new XLWorkbook();
    var worksheet = workbook.Worksheets.Add(sheetName);

    IEnumerable<(int, KeyValuePair<string, string>)> columns = data.Columns.Index();
    IEnumerable<(int, Dictionary<string, object?>)> body = data.Body.Index();

    foreach(var column in columns)
    {
      worksheet.Cell(1, column.Item1 + 1).Value = column.Item2.Value;
      foreach(var line in body)
      {
        worksheet.Cell(line.Item1 + 2, column.Item1 + 1).Value = line.Item2.TryGetValue(column.Item2.Key, out var value) ? value?.ToString() : default;
      }
    }

    using var ms = new MemoryStream();
    workbook.SaveAs(ms);
    return ms.ToArray();
  }
}
