using Refit;

namespace Fz.Finanzaseguros.Application.Common.Models.MPM.Request;

public sealed record MpmAuthRequest(
  [property: AliasAs("usr_Login")] string Username,
  [property: AliasAs("Usr_PassIng")] string Password
);
