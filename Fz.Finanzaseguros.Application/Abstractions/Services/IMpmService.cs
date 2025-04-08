using Fz.Finanzaseguros.Application.Common.Models.MPM.Request;
using Fz.Finanzaseguros.Application.Common.Models.MPM.Response;
using Fz.Finanzaseguros.Application.Common.Models.MPM.Response.Status;
using Refit;

namespace Fz.Finanzaseguros.Application.Abstractions.Services;

public interface IMpmService
{
  [Post("/autenticacion")]
  Task<MpmTokenResponse> Autenticate([Body] object body, CancellationToken cancellationToken = default);

  [Get("/cliente/{nit}")]
  Task<MpmClientStatusResponse> GetClient(string nit, CancellationToken cancellationToken = default);

  [Get("/colaborador/{name}")]
  Task<MpmColaboratorStatusResponse> GetColaborator(string name, CancellationToken cancellationToken = default);

  [Get("/ejecutivos/{nit}")]
  Task<MpmExecutiveStatusResponse> GetExecutive(string nit, CancellationToken cancellationToken = default);

  [Get("/usuarios/{name}")]
  Task<MpmUserStatusResponse> GetUser(string name, CancellationToken cancellationToken = default);

  [Get("/compañias/{name}")]
  Task<MpmCompanyStatusResponse> GetCompany(string name, CancellationToken cancellationToken = default);

  [Patch("/actualizarcliente")]
  Task<MpmClientUpdatedResponse> UpdateClient([Body] MpmUpdateClientRequest req, CancellationToken cancellationToken = default);

  [Patch("/actualizardireccion")]
  Task<MpmAddressUpdatedResponse> UpdateAddress([Body] MpmUpdateAddressRequest req, CancellationToken cancellationToken = default);
}
