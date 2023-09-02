using Microsoft.EntityFrameworkCore;
using MinimalApiBlog.Entities;

namespace MinimalApiBlog.DbContexts
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; } = null!;

        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var topicOne = new Topic { Id = Guid.NewGuid(), Name = "example Topic 1" };
            var articleOne = new Article("article 1", "test article 1", "I'm an article");

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ArticleTopic>()
                .HasKey(at => at.Id);

            modelBuilder.Entity<ArticleTopic>()
                .HasOne(at => at.Article)
                .WithMany(a => a.ArticleTopics)
                .HasForeignKey(at => at.ArticleId);

            modelBuilder.Entity<ArticleTopic>()
                .HasOne(at => at.Topic)
                .WithMany()
                .HasForeignKey(at => at.TopicId);
            
            modelBuilder.Entity<Article>().HasData(
                articleOne,
                new Article("article 2", "test article 2", "I'm an article"),
                new Article("article 3", "test article 3", "I'm an article")
            );

            modelBuilder.Entity<Topic>().HasData(
                topicOne,
                new Topic { Id = Guid.NewGuid(), Name = "example Topic 2" },
                new Topic { Id = Guid.NewGuid(), Name = "example Topic 3" }
            );

            modelBuilder.Entity<ArticleTopic>().HasData(
                new ArticleTopic { Id = Guid.NewGuid(), ArticleId = articleOne.Id, TopicId = topicOne.Id }
            );
        }
    }
}