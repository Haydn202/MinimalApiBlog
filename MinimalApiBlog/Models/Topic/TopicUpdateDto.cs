namespace MinimalApiBlog.Models.Topic;

public record TopicUpdateDto
{
    public required string Name { get; init; }
}