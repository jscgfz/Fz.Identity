using Fz.Core.Domain.Primitives.Abstractions.Common;
using Fz.Core.Result;
using Fz.Identity.Api.Abstractions.Common;
using Fz.Identity.Api.Features.Requests.Dtos;
using Fz.Identity.Api.Models.Files;
using Fz.Identity.Api.Services.Excel;

namespace Fz.Identity.Api.Common.Files;

public abstract class ExcelRenderer<TRow> : IFileRenderer
  where TRow : class
{
  protected Dictionary<string, string> _xslxColumns;
  protected Dictionary<string, Func<TRow, object?>> _xslxBody;

  protected ExcelRenderer(Dictionary<string, string> xslxColumns, Dictionary<string, Func<TRow, object?>> xslxBody)
  {
    _xslxColumns = xslxColumns;
    _xslxBody = xslxBody;
  }

#pragma warning disable CS8618 
  protected ExcelRenderer()
#pragma warning restore CS8618
  {
  }

  public async Task<Result<FileDto>> Render(object result)
  {
    IEnumerable<TRow> data;
    if (
      result.GetType().IsGenericType &&
      result.GetType().GetGenericTypeDefinition() == typeof(IPaginatedResult<>) &&
      result.GetType().GenericTypeArguments.First() == typeof(TRow)
    )
      data = ((IPaginatedResult<TRow>)result).Data;
    else if (
      result.GetType().IsGenericType &&
      result.GetType().GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>)) &&
      result.GetType().GenericTypeArguments.First() == typeof(TRow)
    )
      data = (IEnumerable<TRow>)result;
    else
      return Result.Failure<FileDto>(ResultTypes.Conflict, [new Error("Rendering.Error", "")]);

    ExcelFileData xlsx = new(_xslxColumns, data.Select(d =>
      _xslxBody.Select(b =>
        KeyValuePair.Create(b.Key, b.Value.Invoke(d))).ToDictionary()
      )
    );

    return new FileDto("usuarios", ExcelExporter.ExportToExcel(xlsx, "usuarios"), "application/vnd.openxmlformats-officedocument.spreadsheetml.shee");
  }
}
