using Fz.Core.Cache.Abstractions;
using Fz.Finanzaseguros.Application.Abstractions.Services;
using Fz.Finanzaseguros.Application.Common.Models.MPM.Request;
using Fz.Finanzaseguros.Application.Common.Models.MPM.Response;
using Fz.Finanzaseguros.Infrastructure.Configuration.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Fz.Finanzaseguros.Infrastructure.Configuration.Delegates;

public sealed class MpmAuthenticationDelegate(IServiceProvider provider) : DelegatingHandler
{
  private readonly MpmServiceSettings _settings
    = provider.GetRequiredService<IOptions<MpmServiceSettings>>().Value;
  private readonly ICacheManager _cache
    = provider.GetRequiredService<ICacheManager>();

  protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
  {
    string token = await _cache.GetOrSetAsync($"{nameof(IMpmService)}:token", async () => {
      HttpRequestMessage req = new()
      {
        Method = HttpMethod.Post,
        RequestUri = new("/autenticacion"),
        Content = new StringContent(
          JsonSerializer.Serialize(new MpmAuthRequest(_settings.UserName, _settings.Password)),
          Encoding.UTF8, "application/json"
        )
      };

      HttpResponseMessage resp = await base.SendAsync(req, cancellationToken);
      resp.EnsureSuccessStatusCode();
      MpmTokenResponse token = await resp.Content.ReadFromJsonAsync<MpmTokenResponse>(cancellationToken: cancellationToken) ?? throw new JsonException();
      
      return token.Token;
    }, TimeSpan.FromMinutes(_settings.TokenExpiraionInMinutes), cancellationToken);

    request.Headers.Authorization = new("Bearer", token);
    return await base.SendAsync(request, cancellationToken);
  }
}
