namespace Finanzauto.Identity.Api.Models.Managers.Hashing;

public sealed record HashResponse(string Data, byte[] Hash, byte[] Salt);
