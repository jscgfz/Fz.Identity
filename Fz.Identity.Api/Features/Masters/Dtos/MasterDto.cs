namespace Fz.Identity.Api.Features.Masters.Dtos;

public record MasterDto<TKey>(TKey Id, string Name) where TKey : IEquatable<TKey>;
