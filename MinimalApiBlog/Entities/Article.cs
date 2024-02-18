using blog.Models.Comments;

namespace MinimalApiBlog.Entities
{
    public class Article
    {
        public Guid Id { get; init; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public string ThumbnailUrl { get; set; } =
            "https://upload.wikimedia.org/wikipedia/en/thumb/3/3b/SpongeBob_SquarePants_character.svg/640px-SpongeBob_SquarePants_character.svg.png";
        public DateTime CreatedOn { get; init; }
        public string ContentUrl { get; init; } 
        public Topic? Topic { get; init; }
        public Author? Author { get; init; }
        public List<MainComment>? Comments { get; set; }
        public Guid TopicId { get; init; }
        public Guid AuthorId { get; init; }
    }
}