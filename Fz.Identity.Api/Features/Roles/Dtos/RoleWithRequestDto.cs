using Fz.Identity.Api.Database.Entities;

namespace Fz.Identity.Api.Features.Roles.Dtos;

public class RoleWithRequestDto
{
  public Role Role { get; set; }
  public Request? Request { get; set; }
}
