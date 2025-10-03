using Fz.Core.Domain.Primitives.Abstractions.Common;
using Fz.Core.Result;
using Fz.Identity.Api.Abstractions.Common;
using Fz.Identity.Api.Features.Requests.Dtos;
using Fz.Identity.Api.Features.Roles.Dtos;
using Fz.Identity.Api.Features.Users.Dtos;
using System.Linq;

namespace Fz.Identity.Api.Common.Files;

public sealed class UserFileRenderer : ExcelRenderer<UserDto>
{
  public UserFileRenderer() : base()
  {
    _xslxColumns = new()
    {
      { nameof(UserDto.UserNames), "Nombres" },
      { nameof(UserDto.CreatedDate), "Fecha creación" },
      { nameof(UserDto.Email), "correo electrónico" },
      { nameof(UserDto.Roles), "Roles" },
      { nameof(UserDto.IsActive), "Estado" },
    };


    _xslxBody = new()
    {
      { nameof(UserDto.UserNames), dto =>  dto.UserNames is  IEnumerable<string> names ? string.Join(' ', names) : null },
      { nameof(UserDto.CreatedDate), dto => dto.CreatedDate },
      { nameof(UserDto.Email), dto => dto.Email },
      { nameof(UserDto.Roles), dto => dto.Roles is IEnumerable<RoleDto> roles ? string.Join(", ", roles.Select(r => r.Name)) : null  },
      { nameof(UserDto.IsActive), dto => dto.IsActive is bool cond && cond ? "Activo" : "Inactivo" },
    };
  }
}
