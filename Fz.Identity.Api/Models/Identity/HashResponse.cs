namespace Fz.Identity.Api.Models.Identity;

public sealed record HashResponse(string Data, byte[] Hash, byte[] Salt);