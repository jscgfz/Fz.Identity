using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions.Handlers;
using Fz.Identity.Api.Abstractions.Common;
using Fz.Identity.Api.Features.Requests.Dtos;

namespace Fz.Identity.Api.Features.Files.Commands.ExportFile;

public class ExportFileCommandHandler(IServiceProvider provider) : ICommandHandler<ExportFileCommand, Result<FileDto>>
{
  private readonly IServiceProvider _serviceProvider = provider;
  public Task<Result<FileDto>> Handle(ExportFileCommand request, CancellationToken cancellationToken)
    => _serviceProvider.GetRequiredKeyedService<IFileRenderer>(request.Data.GetType().GetGenericArguments().First().FullName).Render(request.Data);
}
