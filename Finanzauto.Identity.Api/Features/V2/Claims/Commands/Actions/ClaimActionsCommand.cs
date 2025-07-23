using Finanzauto.Core.Result.Extensions;
using Finanzauto.Identity.Api.Features.V2.Claims.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.Claims.Commands.Actions;

public sealed record ClaimActionsCommand(
  IEnumerable<ClaimRequestDto> Actions
) : ICommand<IEnumerable<ClaimResponseDto>>;
