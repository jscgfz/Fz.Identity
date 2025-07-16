using Fz.Core.Domain.Primitives;

namespace Fz.Identity.Api.Database.Entities;

public class Claim : Entity<int>
{
  public int? ParentId { get; set; }
  public int CalimTypeId { get; set; }
  public string Value { get; set; }
  public string Description { get; set; }
  public int? ModuleId { get; set; }
  public int? ActionId { get; set; }

  public virtual Claim? Parent { get; set; }
  public virtual ClaimType ClaimType { get; set; } = default!;
  public virtual IEnumerable<UserClaim> UserClaims { get; set; } = default!;
  public virtual IEnumerable<RoleClaim> RoleClaims { get; set; } = default!;
  public virtual IEnumerable<Claim> Children { get; set; } = default!;

  public virtual IEnumerable<RoleRoute> ReadRoutes { get; set; } = default!;
  public virtual IEnumerable<RoleRoute> CreateRoutes { get; set; } = default!;
  public virtual IEnumerable<RoleRoute> EditRoutes { get; set; } = default!;
  public virtual IEnumerable<RoleRoute> StatusRoutes { get; set; } = default!;
  public virtual IEnumerable<RoleRoute> DownloadRoutes { get; set; } = default!;
  public virtual IEnumerable<RoleRoute> SpecialConditionRoutes { get; set; } = default!;
  public virtual Module? Module { get; set; }
  public virtual Action? Action { get; set; }

  public Claim(int calimTypeId, string value, string description)
  {
    CalimTypeId = calimTypeId;
    Value = value;
    Description = description;
  }

#pragma warning disable CS8618
  public Claim()
#pragma warning restore CS8618
  {
  }
}
