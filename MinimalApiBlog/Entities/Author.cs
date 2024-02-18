namespace MinimalApiBlog.Entities;

public record Author
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public string? Bio { get; init; }
    public string? ProfileUrl { get; init; }
}