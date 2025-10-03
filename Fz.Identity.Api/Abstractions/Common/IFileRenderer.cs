using DocumentFormat.OpenXml.Spreadsheet;
using Fz.Core.Domain.Primitives.Abstractions.Common;
using Fz.Core.Result;
using Fz.Identity.Api.Features.Requests.Dtos;

namespace Fz.Identity.Api.Abstractions.Common;

public interface IFileRenderer
{
  Task<Result<FileDto>> Render(object result);
}
