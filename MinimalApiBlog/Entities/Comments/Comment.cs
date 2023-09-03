namespace blog.Models.Comments;

public class Comment
{
    public Guid Id { get; set; }    
    public string Message { get; set; }
    public DateTime CreatedOn { get; set; }
}