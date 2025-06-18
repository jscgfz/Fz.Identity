
namespace Fz.Core.Result;

public sealed record Error
{
  public string? Code { get; private set; }
  public string Description { get; private set; }
  public static Error Empty => new(string.Empty);

  public Error(string description)
    => Description = description;
  public Error(string code, string description)
    => (Code, Description) = (code, description);

  //public override bool Equals(object? obj)
  //{
  //  return obj is Error error &&
  //         Code == error.Code &&
  //         Description == error.Description;
  //}

  //public override int GetHashCode()
  //{
  //  return HashCode.Combine(Code, Description);
  //}

}