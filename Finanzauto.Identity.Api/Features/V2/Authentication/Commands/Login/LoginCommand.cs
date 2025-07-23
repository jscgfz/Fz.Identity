using Finanzauto.Core.Result.Extensions;
using Finanzauto.Identity.Api.Features.V2.Authentication.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.Authentication.Commands.Login;

public sealed record LoginCommand(
  string UserName,
  string Password,
  Guid? ApplicationId,
  int? ApplicationIndex
) : ICommand<TokenResponseDto>;
