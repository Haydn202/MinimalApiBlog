using MinimalApiBlog.Entities;

namespace blog.Models.Comments;

public class MainComment
{
    public Guid Id { get; set; }    
    public string Message { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid ArticleId { get; set; }
    public List<SubComment> SubComments { get; set; }
}