﻿using MediatR;

namespace Fz.Core.Result.Extensions.Abstractions.Handlers;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
  where TQuery : IQuery<TResponse>
  where TResponse : Result { }
