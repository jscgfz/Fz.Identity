using ClosedXML.Excel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Fz.Identity.Api.Services.Excel;

public static class ExcelExporter
{
  public static byte[] ExportToExcel<T>(IEnumerable<T> data, string sheetName)
  {
    using var workbook = new XLWorkbook();
    var worksheet = workbook.Worksheets.Add(sheetName);

    var props = data.GetType().GetGenericArguments().First().GetProperties();

    for (int i = 0; i < props.Length; i++)
    {
      var displayAttr = props[i].GetCustomAttribute<DisplayAttribute>();
      var header = displayAttr?.Name ?? props[i].Name;
      worksheet.Cell(1, i + 1).Value = header;
    }

    int row = 2;
    foreach (var item in data)
    {
      for (int i = 0; i < props.Length; i++)
      {
        worksheet.Cell(row, i + 1).Value = props[i].GetValue(item)?.ToString();
      }
      row++;
    }

    using var ms = new MemoryStream();
    workbook.SaveAs(ms);
    return ms.ToArray();
  }
}
