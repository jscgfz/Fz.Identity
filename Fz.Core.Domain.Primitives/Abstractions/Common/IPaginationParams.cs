namespace Fz.Core.Domain.Primitives.Abstractions.Common;

public interface IPaginationParams
{
  int? PageIndex { get; }
  int? PageSize { get; }
  int? Page { get; }
}
