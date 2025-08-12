using Fz.Core.Result;
using Fz.Core.Result.Extensions.Abstractions;
using Fz.Identity.Api.Features.Users.Dtos;
using System.Windows.Input;

namespace Fz.Identity.Api.Features.Users.Commands.ValidateUser;

public sealed record ValidateUserCommand(string UserName) : ICommand<Result<ValidateUserDto>>;
