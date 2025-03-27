using MediatR;

namespace Fz.Core.Result.Extensions.Abstractions;
public interface ICommand<TResponse> : IRequest<TResponse> where TResponse : Result { }
