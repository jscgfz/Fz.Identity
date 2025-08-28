using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Requests.Dtos;

namespace Fz.Identity.Api.Features.Files.Commands.ExportFile;

public sealed record ExportFileCommand(
  string Entity,
  object Query) : ICommand<Result<FileDto>>;
