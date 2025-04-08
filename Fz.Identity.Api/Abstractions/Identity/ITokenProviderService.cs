using Fz.Core.Result;
using Fz.Identity.Api.Database.Entities;
using Fz.Identity.Api.Features.Auth.Dtos;

namespace Fz.Identity.Api.Abstractions.Identity;

public interface ITokenProviderService
{
  Task<Result<IdentityResponseDto>> GenerateToken(User user, int applicationId);
  Task<Result<IdentityResponseDto>> RefreshToken();
}
