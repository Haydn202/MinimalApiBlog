namespace MinimalApiBlog.Models.Article;

public class Article
{
    public Article(string title, string description, List<string> topic, string contentUrl)
    {
        Id = new Guid();
        Title = title;
        Description = description;
        Topics = topic;
        ContentUrl = contentUrl;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> Topics { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public List<Guid>? Comments { get; set; } 
    public string ContentUrl { get; set; }
}