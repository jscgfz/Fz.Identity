using System.Text.Json.Serialization;

namespace Finanzauto.Identity.Api.Domain.Enums.Masivian;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MasivianAttachmentActions
{
  [JsonStringEnumMemberName("generate-pdf")] GeneratePdf = 0x1,
  [JsonStringEnumMemberName("download-delete")] DownloadDelete = 0x2
}
