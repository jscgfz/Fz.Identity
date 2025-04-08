using Fz.Core.Domain.Primitives;

namespace Fz.Identity.Api.Database.Entities;

public class Route : Entity<int>
{
  public int ApplitionId { get; set; }
  public string Name { get; set; }
  public string UrlImg { get; set; }
  public string Path { get; set; }
  public int Order { get; set; }
  public bool ExcludeNav { get; set; }
  public string Component { get; set; }
  public int? ParentId { get; set; }

  public virtual Application Application { get; set; } = default!;
  public virtual Route? Parent { get; set; } = default;
  public virtual IEnumerable<Route> Children { get; set; } = default!;
  public virtual IEnumerable<RoleRoute> Roles { get; set; } = default!;

  public Route(int applicationId, string name, string urlImg, string path, int order, bool excludeNav, string component)
  {
    ApplitionId = applicationId;
    Name = name;
    UrlImg = urlImg;
    Path = path;
    Order = order;
    ExcludeNav = excludeNav;
    Component = component;
  }

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
  public Route() { }
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de agregar el modificador "required" o declararlo como un valor que acepta valores NULL.
}
