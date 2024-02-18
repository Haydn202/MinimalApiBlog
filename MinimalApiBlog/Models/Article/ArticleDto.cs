namespace MinimalApiBlog.Models.Article;

public record ArticleDto
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Description { get; init; }
    // public List<string>? Topics { get; set; }
    public DateTime CreatedOn { get; init; } = DateTime.Now;
    // public List<Guid>? Comments { get; set; }
    public string ContentUrl { get; init; }
}