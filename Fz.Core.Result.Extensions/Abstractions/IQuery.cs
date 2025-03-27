using MediatR;

namespace Fz.Core.Result.Extensions.Abstractions;

public interface IQuery<TResponse> : IRequest<TResponse> where TResponse : Result { }
