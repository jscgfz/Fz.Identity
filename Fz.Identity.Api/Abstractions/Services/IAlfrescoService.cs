using Fz.Core.Result;
using Fz.Identity.Api.Features.Users.Commands.AddUser;

namespace Fz.Identity.Api.Abstractions.Services;

public interface IAlfrescoService
{
  Task<Result<string>> UploadFile(string username, string fileBase64);
  Task<Result<string>> GetBase64File(string nodeId);
}
