using Fz.Core.Result;
using Fz.Identity.Api.Abstractions.Services;
using Fz.Identity.Api.Services.Alfresco.Settings;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Fz.Identity.Api.Services.Alfresco;

public class AlfrescoService(IServiceProvider provider) : IAlfrescoService
{
  private readonly IOptions<AlfrescoSettings> _settings = provider.GetRequiredService<IOptions<AlfrescoSettings>>();

  public async Task<Result<string>> UploadFile(string username, string fileBase64)
  {
    var match = Regex.Match(fileBase64, @"data:(?<type>.+?);base64,(?<data>.+)");
    if (match.Success)
    {
      string contentType = match.Groups["type"].Value;
      string base64Data = match.Groups["data"].Value;
      HttpClient client = new();
      // Crear el encabezado de autenticación básica
      var authToken = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_settings.Value.Username}:{_settings.Value.Password}"));
      client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);

      var formData = new MultipartFormDataContent
      {
        { new StringContent(username), "relativePath" },
        { new StringContent("Foto"), "name" },
        { new StringContent("cm:content"), "nodeType" },
        { new StringContent("true"), "overwrite" }
      };

      byte[] photoBytes = Convert.FromBase64String(base64Data);
      var fileContent = new ByteArrayContent(photoBytes);
      fileContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
      formData.Add(fileContent, "filedata", "Foto.jpg");

      HttpResponseMessage response = await client.PostAsync($"{_settings.Value.BaseUrl}/nodes/{_settings.Value.PhotoNode}/children", formData);
      string result = await response.Content.ReadAsStringAsync();

      if (!response.IsSuccessStatusCode)
        return Result.Failure<string>(ResultTypes.BadRequest, [new Error("Alfresco.CreateNode", $"Creación fallida- respuesta servicio {response.StatusCode}")]);
      using var doc = JsonDocument.Parse(result);

      string nodeId = doc.RootElement
                     .GetProperty("entry").GetProperty("id").GetString();

      return Result.Success(nodeId);
    }
    return Result.Failure<string>(ResultTypes.BadRequest, [new Error("PhotoBase64.Invalid", "Formato foto base 64 invalido")]);
  }

  public async Task<Result<string>> GetBase64File(string nodeId)
  {
    HttpClient client = new();
    // Crear el encabezado de autenticación básica
    var authToken = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_settings.Value.Username}:{_settings.Value.Password}"));
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authToken);

    var documentBytes = await client.GetByteArrayAsync($"{_settings.Value.BaseUrl}/nodes/{nodeId}/content");
    var base64Content = Convert.ToBase64String(documentBytes);

    return base64Content;
  }
}
