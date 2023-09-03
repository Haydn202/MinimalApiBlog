namespace blog.Models.Comments;

public class SubComment
{
    public Guid Id { get; set; }    
    public string Message { get; set; }
    public DateTime CreatedOn { get; set; }
    public Guid MainCommentId { get; set; }
}