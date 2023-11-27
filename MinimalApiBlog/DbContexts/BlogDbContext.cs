using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using blog.Models.Comments;
using MinimalApiBlog.Entities;

namespace MinimalApiBlog.DbContexts
{
    public class BlogDbContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<MainComment> MainComments { get; set; }
        public DbSet<SubComment> SubComments { get; set; }

        public BlogDbContext(DbContextOptions<BlogDbContext> options)
            : base(options)
        {
        }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Topic>()
            .HasKey(t => t.Id);

        modelBuilder.Entity<Article>()
            .HasOne(a => a.Topic)
            .WithMany()
            .HasForeignKey(a => a.TopicId);

        modelBuilder.Entity<Article>()
            .HasOne(a => a.Author);

        modelBuilder.Entity<Article>()
            .HasMany(a => a.Comments)
            .WithOne()
            .HasForeignKey(c => c.ArticleId);

        modelBuilder.Entity<MainComment>()
            .HasMany(mc => mc.SubComments)
            .WithOne()
            .HasForeignKey(sc => sc.MainCommentId);

        // Seed data
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        var topic1 = new Topic { Id = Guid.NewGuid(), Name = "Technology" };
        var topic2 = new Topic { Id = Guid.NewGuid(), Name = "Science" };
        var topic3 = new Topic { Id = Guid.NewGuid(), Name = "Travel" };
        
        // Sample Topics
        modelBuilder.Entity<Topic>().HasData(
            topic1,
            topic2,
            topic3
        );

        var author1 = new Author
            { Id = Guid.NewGuid(), Name = "John Doe", Bio = "Tech Enthusiast", ProfileUrl = "https://example.com/johndoe" };
        var author2 = new Author
            { Id = Guid.NewGuid(), Name = "John Doe", Bio = "Tech Enthusiast", ProfileUrl = "https://example.com/johndoe" };
        // Sample Authors
        modelBuilder.Entity<Author>().HasData(
            author1,
            author2
        );

        var article1 = new Article
        {
            Id = Guid.NewGuid(),
            Title = "Introduction to AI",
            Description = "A beginner's guide to Artificial Intelligence",
            TopicId = topic1.Id,
            AuthorId = author1.Id,
            CreatedOn = DateTime.Now,
            ContentUrl = "https://example.com/article1"
        };

        var article2 = new Article
        {
            Id = Guid.NewGuid(),
            Title = "Space Exploration",
            Description = "Discovering the wonders of the universe",
            TopicId = topic2.Id,
            AuthorId = author2.Id,
            CreatedOn = DateTime.Now,
            ContentUrl = "https://example.com/article2"
        };

        // Sample Articles
        modelBuilder.Entity<Article>().HasData(
            article1,
            article2
        );

        var comment1 = new MainComment
        {
            Id = Guid.NewGuid(),
            Message = "Great article!",
            ArticleId = article1.Id,
            CreatedOn = DateTime.Now
        };
        var comment2 = new MainComment
        {
            Id = Guid.NewGuid(),
            Message = "I found this very informative.",
            ArticleId = article1.Id,
            CreatedOn = DateTime.Now
        };
        
        // Sample MainComments
        modelBuilder.Entity<MainComment>().HasData(
            comment1,
            comment2
        );

        // Sample SubComments
        modelBuilder.Entity<SubComment>().HasData(
            new SubComment
            {
                Id = Guid.NewGuid(),
                Message = "Thank you!",
                MainCommentId = comment2.Id,
                CreatedOn = DateTime.Now
            },
            new SubComment
            {
                Id = Guid.NewGuid(),
                Message = "I agree!",
                MainCommentId = comment2.Id,
                CreatedOn = DateTime.Now
            }
        );
        }
    }
}