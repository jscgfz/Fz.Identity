using MediatR;

namespace Fz.Core.Result.Extensions.Abstractions.Handlers;

public interface IEventHandler<in TEvent> : INotificationHandler<TEvent>
  where TEvent : IEvent { }
