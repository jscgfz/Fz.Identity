using Refit;

namespace Fz.Finanzaseguros.Application.Common.Models.MPM.Request;

public record MpmUpdateClientRequest(
  [property: AliasAs("clI_Id")] int Id,
  [property: AliasAs("clI_Nombre")] string Name,
  [property: AliasAs("clI_Apellido1")] string LastName1,
  [property: AliasAs("clI_Apellido2")] string LastName2,
  [property: AliasAs("clI_Sexo")] int GenderId,
  [property: AliasAs("clI_Nacimiento")] DateTime BirthDate,
  [property: AliasAs("vcO_ID")] int ComunicationViaId
);
