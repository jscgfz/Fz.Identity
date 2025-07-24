using Fz.Core.Result;
using Fz.Identity.Api.Features.Users.Commands.AddUser;

namespace Fz.Identity.Api.Abstractions.Services;

public interface IAlfrescoService
{
  Task<Result<string>> UploadFile(string username, string fileBase64);
  Task<Result<byte[]>> GetFileBytes(string nodeId);
  Task<Result<string>> UploadAuthFile(Guid roleId, int requestId, IFormFile authorizationFile);
}
