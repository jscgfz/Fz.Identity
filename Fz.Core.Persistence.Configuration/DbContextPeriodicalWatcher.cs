using Fz.Core.Persistence.Configuration.Abstractions;
using Microsoft.Extensions.Primitives;

namespace Fz.Core.Persistence.Configuration;

internal sealed class DbContextPeriodicalWatcher : IContextConfigurationSourceWatcher
{
  private readonly TimeSpan _interval;
  private IChangeToken? _changeToken;
  private readonly Timer _timer;
  private CancellationTokenSource? _cancellationTokenSource;

  public DbContextPeriodicalWatcher(TimeSpan interval)
  {
    _interval = interval;
    _timer = new(TimerCallback, null, TimeSpan.Zero, _interval);

  }

  private void TimerCallback(object? state)
    => _cancellationTokenSource?.Cancel();

  public void Dispose()
  {
    _timer.Dispose();
    _cancellationTokenSource?.Dispose();
  }

  public IChangeToken Watch()
  {
    _cancellationTokenSource = new();
    _changeToken = new CancellationChangeToken(_cancellationTokenSource.Token);

    return _changeToken;
  }
}
