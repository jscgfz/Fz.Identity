using DocumentFormat.OpenXml.Spreadsheet;
using Fz.Core.Domain.Primitives.Abstractions.Common;
using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Requests.Dtos;
using Fz.Identity.Api.Features.Users.Dtos;

namespace Fz.Identity.Api.Features.Files.Commands.ExportFile;

public sealed record ExportFileCommand(
  IEnumerable<object> Data
) : ICommand<Result<FileDto>>
{
  
}
