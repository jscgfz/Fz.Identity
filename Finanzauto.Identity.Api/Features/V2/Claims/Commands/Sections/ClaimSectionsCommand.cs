using Finanzauto.Core.Result.Extensions;
using Finanzauto.Identity.Api.Features.V2.Claims.Dtos;

namespace Finanzauto.Identity.Api.Features.V2.Claims.Commands.Sections;

public sealed record ClaimSectionsCommand(
  IEnumerable<ClaimRequestDto> Sections
) : ICommand<ClaimResponseDto>;
