using blog.Models.Comments;

namespace MinimalApiBlog.Entities
{
    public class Article
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ContentUrl { get; set; } 
        public Topic Topic { get; set; }
        public Author Author { get; set; }
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
    
    public class MainComment
    {
        public Guid Id { get; set; }    
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid ArticleId { get; set; }
        public List<SubComment> SubComments { get; set; }
    }
    
    public class SubComment
    {
        public Guid Id { get; set; }    
        public string Message { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid MainCommentId { get; set; }
    }
}