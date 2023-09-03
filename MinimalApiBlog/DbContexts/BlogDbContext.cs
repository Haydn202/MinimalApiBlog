using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

            // Configure the Topic entity
            modelBuilder.Entity<Topic>()
                .HasKey(t => t.Id);

            // Configure other entities and relationships here
            modelBuilder.Entity<Article>()
                .HasOne(a => a.Topic)
                .WithMany()
                .HasForeignKey(a => a.TopicId);

            modelBuilder.Entity<Article>()
                .HasOne(a => a.Author)
                .WithMany()
                .HasForeignKey(a => a.AuthorId);

            modelBuilder.Entity<Article>()
                .HasMany(a => a.Comments)
                .WithOne()
                .HasForeignKey(c => c.ArticleId);

            modelBuilder.Entity<MainComment>()
                .HasMany(mc => mc.SubComments)
                .WithOne()
                .HasForeignKey(sc => sc.MainCommentId);
        }
    }
}