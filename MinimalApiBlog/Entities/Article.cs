namespace MinimalApiBlog.Entities
{
    public class Article
    {
        public Article(string title, string description, string contentUrl)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            CreatedOn = DateTime.Now;
            ContentUrl = contentUrl;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ContentUrl { get; set; } 
        public ICollection<ArticleTopic> ArticleTopics { get; set; } = new List<ArticleTopic>();
    }

    public class Topic
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class ArticleTopic
    {
        public Guid Id { get; set; }
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
        public Guid TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}