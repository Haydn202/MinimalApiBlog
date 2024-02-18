namespace MinimalApiBlog.Models.Article
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
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}