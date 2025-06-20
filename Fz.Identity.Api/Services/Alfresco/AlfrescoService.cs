using Fz.Core.Result;
using System.IO;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using System.Xml.Linq;
using Fz.Identity.Api.Services.Identity.Settings;
using Microsoft.Extensions.Options;
using Fz.Identity.Api.Services.Alfresco.Settings;
using Fz.Identity.Api.Features.Users.Dtos;
using System.Text.RegularExpressions;
using Fz.Identity.Api.Features.Users.Commands.AddUser;
using Fz.Identity.Api.Database.Entities;
using Azure;
using Fz.Identity.Api.Abstractions.Services;

namespace Fz.Identity.Api.Services.Alfresco;

public class AlfrescoService(IServiceProvider provider) : IAlfrescoService
{
  private readonly IOptions<AlfrescoSettings> _settings = provider.GetRequiredService<IOptions<AlfrescoSettings>>();

  public async Task<Result> UploadFile(AddUserCommand user)
  {
    var match = Regex.Match(user.photoBase64, @"data:(?<type>.+?);base64,(?<data>.+)");
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
        { new StringContent(user.UserName), "relativePath" },
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
        return Result.Failure(ResultTypes.BadRequest, [new Error("Alfresco.CreateNode", $"Creación fallida- respuesta servicio {response.StatusCode}")]);
      
      return Result.Success();
    }
    return Result.Failure(ResultTypes.BadRequest, [new Error("PhotoBase64.Invalid", "Formato foto base 64 invalido")]);
  }
}
