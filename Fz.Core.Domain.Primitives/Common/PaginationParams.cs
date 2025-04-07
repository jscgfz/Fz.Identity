using Fz.Core.Domain.Primitives.Abstractions.Common;

namespace Fz.Core.Domain.Primitives.Common;

public abstract record PaginationParams(int? PageIndex, int? PageSize, int? Page) : IPaginationParams;
