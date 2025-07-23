using Finanzauto.Core.Domain.Primitives;
using Finanzauto.Identity.Api.Domain.Entities.Authorization;

namespace Finanzauto.Identity.Api.Domain.Entities.Configuration;

public class Route : Entity<Guid>
{
  public string Name { get; set; }
  public string? Description { get; set; }
  public string? UrlImg { get; set; }
  public string Path { get; set; }
  public bool ExcludeNav { get; set; }
  public string Component { get; set; }

  public virtual ICollection<RoleRoute> Roles { get; set; } = default!;

  public Route(string name, string? description, string? urlImg, string path, bool excludeNav, string component)
  {
    Name = name;
    Description = description;
    UrlImg = urlImg;
    Path = path;
    ExcludeNav = excludeNav;
    Component = component;
  }



#pragma warning disable CS8618
  public Route() { }
#pragma warning restore CS8618
}
