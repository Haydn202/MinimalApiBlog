namespace MinimalApiBlog.Entities;

public class Author
{
    public Guid Id { get; init; }
    public required string Name { get; init; }
    public string? Bio { get; init; }
    public string? ProfileUrl { get; init; }
}