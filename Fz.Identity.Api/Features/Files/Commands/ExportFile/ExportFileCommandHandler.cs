using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Common.Mappers;
using Fz.Identity.Api.Features.Managements.Queries;
using Fz.Identity.Api.Features.Requests.Dtos;
using Fz.Identity.Api.Features.Requests.Queries.Requests;
using Fz.Identity.Api.Features.Roles.Queries.Roles;
using Fz.Identity.Api.Features.Users.Dtos;
using Fz.Identity.Api.Features.Users.Queries.Users;
using Fz.Identity.Api.Services.Excel;
using MediatR;

namespace Fz.Identity.Api.Features.Files.Commands.ExportFile;

public class ExportFileCommandHandler(IServiceProvider provider) : ICommandHandler<ExportFileCommand, Result<FileDto>>
{
  private readonly ISender _sender
     = provider.GetRequiredService<ISender>();
  public async Task<Result<FileDto>> Handle(ExportFileCommand request, CancellationToken cancellationToken)
  {
    var result = await _sender.Send(request.Query);
    var resultType = result.GetType();
    var valueProp = resultType.GetProperty("Value");
    var value = valueProp.GetValue(result);
    var dataProp = value.GetType().GetProperty("Data");
    
    if (dataProp is null)
      return Result.Failure<FileDto>(type: ResultTypes.NotFound, [new Error("Entity.NotFound", "No se encontraron registros")]);

    var data = (IEnumerable<object>)(dataProp.GetValue(value) ?? Array.Empty<object>());

    var excelBytes = ExcelExporter.ExportToExcel(data, request.Entity);
    return Result.Success(new FileDto(
     $"{request.Entity}.xlsx",
     excelBytes,
     "application / vnd.openxmlformats - officedocument.spreadsheetml.sheet"
     ));
  }
}
