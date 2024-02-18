namespace MinimalApiBlog.Entities;

public record Topic
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
}