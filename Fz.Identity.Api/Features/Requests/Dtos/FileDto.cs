namespace Fz.Identity.Api.Features.Requests.Dtos;

public sealed record FileDto(
  string Name,
  byte[] FileBytes,
  string ContentType
  );
