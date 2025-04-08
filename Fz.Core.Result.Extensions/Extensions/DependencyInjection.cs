using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Fz.Core.Result.Extensions.Extensions;

public static class DependencyInjection
{
  public static WebApplicationBuilder WithResultExtensions(this WebApplicationBuilder builder, Action<MediatRServiceConfiguration>? options = default)
  {
    builder.Services.AddMediatR(mediatr => options?.Invoke(mediatr));
    return builder;
  }
}
