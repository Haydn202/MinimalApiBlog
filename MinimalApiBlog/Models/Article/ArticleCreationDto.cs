using System.ComponentModel.DataAnnotations;
using blog.Models.Comments;
using MinimalApiBlog.Entities;

namespace MinimalApiBlog.Models.Article;

public class ArticleCreationDto
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Title { get; set; }
    
    [Required]
    [StringLength(1000, MinimumLength = 3)]
    public string Description { get; set; } 
    
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public string ContentUrl { get; set; }
    public Guid TopicId { get; set; }
    public Guid AuthorId { get; set; }
}