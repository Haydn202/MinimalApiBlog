using blog.Models.Comments;

namespace MinimalApiBlog.Entities
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; } =
            "https://upload.wikimedia.org/wikipedia/en/thumb/3/3b/SpongeBob_SquarePants_character.svg/640px-SpongeBob_SquarePants_character.svg.png";
        public DateTime CreatedOn { get; set; }
        public string ContentUrl { get; set; } 
        public Topic? Topic { get; set; }
        public Author? Author { get; set; }
        public List<MainComment>? Comments { get; set; }
        public Guid TopicId { get; set; }
        public Guid AuthorId { get; set; }
    }

    public class Topic
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class Author
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ProfileUrl { get; set; }
    }
}