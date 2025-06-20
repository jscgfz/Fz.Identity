using Fz.Core.Result;
using Fz.Identity.Api.Features.Users.Commands.AddUser;

namespace Fz.Identity.Api.Abstractions.Services;

public interface IAlfrescoService
{
  Task<Result> UploadFile(AddUserCommand user);
}
