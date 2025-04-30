using Microsoft.Extensions.Primitives;

namespace Fz.Core.Persistence.Configuration.Abstractions;

internal interface IContextConfigurationSourceWatcher : IDisposable
{
  IChangeToken Watch();
}
