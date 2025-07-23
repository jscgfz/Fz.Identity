using Finanzauto.Identity.Api.Models.Apps.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.Users.Dtos;

public sealed record CreatedUserDto(
  Guid Id,
  string? DocumentTypeId,
  string? DocumentNumber,
  string FirstName,
  string? SecondName,
  string FirstLastName,
  string SecondLastName,
  string Email,
  string? PhoneNumber,
  string? Address,
  IEnumerable<UserAppResumeDto> Apps
);
