using Fz.Finanzaseguros.Application.Common.Models.Sarlaft.Response;
using Refit;

namespace Fz.Finanzaseguros.Application.Abstractions.Services;

public interface ISarlaftService
{
  [Get("/sarlafts")]
  Task<SarlaftSarlaftResponse> GetSarlaft([Query] int identificationNumber);
}
