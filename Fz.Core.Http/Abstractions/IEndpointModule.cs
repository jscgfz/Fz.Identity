using Microsoft.AspNetCore.Routing;

namespace Fz.Core.Http.Abstractions;

public interface IEndpointModule
{
  void MapEndpoints(IEndpointRouteBuilder builder);
}
