using blog.Models.Comments;
using MinimalApiBlog.Entities;

namespace MinimalApiBlog.Models.Article;

public abstract class ArticleCreationDto
{
    public string Title { get; set; }
    public string Description { get; set; } 
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public string ContentUrl { get; set; }
    public Guid TopicId { get; set; }
    public Guid AuthorId { get; set; }
}