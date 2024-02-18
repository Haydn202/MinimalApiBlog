namespace MinimalApiBlog.Models.Topic
{
    // public enum TopicDto
    // {
    //     DevOps,
    //     Language,
    //     Cloud,
    //     Frontend,
    //     Backend,
    //     DataStructures,
    //     Algorithms,
    //     Scripting,
    //     Design,
    //     Programing
    // }
    //
    public record TopicDto
    {
        public Guid Id { get; init; }
        public required string Name { get; init; }
    }
}