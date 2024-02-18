namespace MinimalApiBlog.Models.Topic;

public abstract record TopicCreationDto
{
    public required string Name { get; init; }
}