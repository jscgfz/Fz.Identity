using Fz.Core.Result;
using Fz.Identity.Api.Abstractions.Services;
using Fz.Identity.Api.Models.LDAP.Response;
using Fz.Identity.Api.Services.LDAP.Settings;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace Fz.Identity.Api.Services.LDAP;

public class LDAPService(IServiceProvider provider) : ILDAPService 
{
  private readonly IOptions<LDAPSettings> _settings = provider.GetRequiredService<IOptions<LDAPSettings>>();
  public async Task<GetRolesResponse> GetRolesByApp(string alias)
  {
    using HttpClient client = new();
    HttpRequestMessage request = new(HttpMethod.Post, new Uri($"{_settings.Value.BaseUrl}GetRolesApp"))
    {
      Content = new StringContent(JsonSerializer.Serialize(new
      {
        Firma = _settings.Value.Signature,
        Dominio = alias,
      }), Encoding.UTF8, "application/json")
    };
    HttpResponseMessage response = await client.SendAsync(request);
    if (!response.IsSuccessStatusCode)
      return null;
    var responseContent = await response.Content.ReadAsStringAsync();
    return JsonSerializer.Deserialize<GetRolesResponse>(responseContent);
  }

  public async Task<Result<GetDetailUserResponse>> GetDetailUSer(string userName, string app)
  {
    using HttpClient client = new();
    HttpRequestMessage request = new(HttpMethod.Post, new Uri($"{_settings.Value.BaseUrl}GetDetailUserApp"))
    {
      Content = new StringContent(JsonSerializer.Serialize(new
      {
        Usuario = userName,
        Firma = _settings.Value.Signature,
        Dominio = app
      }), Encoding.UTF8, "application/json")
    };
    HttpResponseMessage response = await client.SendAsync(request);
    if (!response.IsSuccessStatusCode)
      return Result.Failure<GetDetailUserResponse>(ResultTypes.InternalServerError, [new Error("LDAPAuthService.DetailUser", $"Obtención fallida- respuesta servicio {response.StatusCode}")]);

    var responseContent = await response.Content.ReadAsStringAsync();
    return Result.Success(JsonSerializer.Deserialize<GetDetailUserResponse>(responseContent));
  }
}
