using Fz.Core.Cache.Abstractions;
using Fz.Finanzaseguros.Application.Abstractions.Services;
using Fz.Finanzaseguros.Application.Common.Models.MPM.Response;
using Fz.Finanzaseguros.Application.Common.Models.Sarlaft.Response;
using Fz.Finanzaseguros.Infrastructure.Configuration.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Fz.Finanzaseguros.Infrastructure.Configuration.Delegates;

public sealed class SarlaftAuthenticationDelegate(IServiceProvider provider) : DelegatingHandler
{
  private readonly SarlaftServiceSettings _settings
    = provider.GetRequiredService<IOptions<SarlaftServiceSettings>>().Value;
  private readonly ICacheManager _cache
    = provider.GetRequiredService<ICacheManager>();

  protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
  {
    TimeSpan expiration = TimeSpan.Zero;
    string token = await _cache.GetOrSetAsync($"{nameof(ISarlaftService)}:token", async () =>
    {
      HttpRequestMessage req = new()
      {
        Method = HttpMethod.Post,
        RequestUri = new("/auth/login"),
        Content = new StringContent(
          JsonSerializer.Serialize(new { Email = _settings.UserName, _settings.Password }),
          Encoding.UTF8, "application/json"
        )
      };

      HttpResponseMessage resp = await base.SendAsync(req, cancellationToken);
      resp.EnsureSuccessStatusCode();
      SarlaftAuthResponse token = await resp.Content.ReadFromJsonAsync<SarlaftAuthResponse>(cancellationToken: cancellationToken) ?? throw new JsonException();

      expiration = (DateTime.UtcNow - token.ExpirationDate);

      return token.AccesToken;
    }, expiration, cancellationToken);

    request.Headers.Authorization = new("Bearer", token);
    return await base.SendAsync(request, cancellationToken);
  }
}
