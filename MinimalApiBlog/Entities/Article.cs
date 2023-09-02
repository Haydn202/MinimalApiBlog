namespace MinimalApiBlog.Entities;

public class Article
{
    public Article(string title, string description, string contentUrl)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        // Topics = topics;
        // Comments = comments;
        ContentUrl = contentUrl;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    // public List<string> Topics { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    // public List<Guid>? Comments { get; set; } 
    public string ContentUrl { get; set; }
}   