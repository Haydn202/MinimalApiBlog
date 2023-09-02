using Microsoft.EntityFrameworkCore;
using MinimalApiBlog.Entities;

namespace MinimalApiBlog.DbContexts;

public class BlogDbContext : DbContext
{
    public DbSet<Article> Articles { get; set; } = null!;

    public BlogDbContext(DbContextOptions<BlogDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _ = modelBuilder.Entity<Article>().HasData(
            new Article(
                "article 1", "test article 1", "I'm an article"
            ),
            new Article(
                "article 2", "test article 2", "I'm an article"
            ),
            new Article(
                "article 3", "test article 3", "I'm an article"
            )
        );
        
        base.OnModelCreating(modelBuilder);
    }
}