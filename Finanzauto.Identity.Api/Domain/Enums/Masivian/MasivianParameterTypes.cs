using System.Text.Json.Serialization;

namespace Finanzauto.Identity.Api.Domain.Enums.Masivian;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MasivianParameterTypes
{
  [JsonStringEnumMemberName("masiv-template/html")] TemplateHtml = 0x1,
  [JsonStringEnumMemberName("text/html")] TextHtml = 0x2,
  [JsonStringEnumMemberName("text")] Text = 0x3,
}
