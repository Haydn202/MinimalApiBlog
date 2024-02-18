namespace MinimalApiBlog.Models.Article;

public record ArticleUpdateDto
{
    public string Title { get; set; }
    public string Description { get; set; } 
    public string ContentUrl { get; set; }
    public Guid TopicId { get; set; }
    public Guid AuthorId { get; set; }
}
