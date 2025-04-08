using Fz.Identity.Api.Database.Entities;

namespace Fz.Identity.Api.Models.Identity;

public sealed record IdentityStorage(IEnumerable<ClaimStorage> Claims, Application App, User User, IEnumerable<Role> Roles);
