using Fz.Core.Domain.Primitives;
using Fz.Identity.Api.Settings;

namespace Fz.Identity.Api.Database.Entities;

public class RequestStatus : MasterEntity<int>
{
  private string _name;
  public override string Name { get => _name; set => _name = Enum.TryParse(value, out RequestStatuses type) ? type.ToString() : throw new ArgumentException(); }
  public RequestStatuses Type { get => Enum.Parse<RequestStatuses>(_name); set => _name = value.ToString(); }
}
