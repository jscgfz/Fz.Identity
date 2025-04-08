using Fz.Core.Result;
using Fz.Identity.Api.Database.Entities;
using System.Text.Json;

namespace Fz.Identity.Api.Abstractions.Identity;

public interface ICredentialValidatorService
{
  Task<Result<User>> ValidateCredentials(JsonElement credentials);

  Task<Result> CreateCredential(Guid userId, string username);
}
