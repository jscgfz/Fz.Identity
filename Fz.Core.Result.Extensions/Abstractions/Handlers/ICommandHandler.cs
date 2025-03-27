using MediatR;

namespace Fz.Core.Result.Extensions.Abstractions.Handlers;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
  where TCommand : ICommand<TResponse>
  where TResponse : Result { }
