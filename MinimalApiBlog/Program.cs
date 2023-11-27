using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MinimalApiBlog.DbContexts;
using MinimalApiBlog.Entities;
using MinimalApiBlog.Models.Article;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogDbContext>(o => o.UseSqlite(
    builder.Configuration["ConnectionStrings:BlogDBConnectionString"]));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/articles", async Task<Ok<IEnumerable<ArticleDto>>> (BlogDbContext blogDbContext, IMapper mapper) =>
{
    return TypedResults.Ok(mapper.Map<IEnumerable<ArticleDto>>(await blogDbContext.Articles.ToListAsync()));
});

app.MapGet("/articles/{articleId:guid}", async Task<Results<NotFound, Ok<ArticleDto>>> (Guid articleId, BlogDbContext blogDbContext, IMapper mapper) =>
{
    var article = await blogDbContext.Articles.FirstOrDefaultAsync(a => a.Id == articleId);

    if (article == null)
    {
        return TypedResults.NotFound();
    }
    
    return TypedResults.Ok(mapper.Map<ArticleDto>(article));
});

app.MapPost("/articles", async (BlogDbContext blogDbContext, IMapper mapper, ArticleCreationDto article) =>
{
    var articleEntity = mapper.Map<Article>(article);
    blogDbContext.Add(articleEntity);
    await blogDbContext.SaveChangesAsync();

    var articleToReturn = mapper.Map<ArticleDto>(articleEntity);
    return TypedResults.Ok(articleToReturn);
});

app.MapGet("/topics", async Task<Ok<IEnumerable<TopicDto>>> (BlogDbContext blogDbContext, IMapper mapper) =>
{
    return TypedResults.Ok(mapper.Map<IEnumerable<TopicDto>>(await blogDbContext.Topics.ToListAsync()));
});

app.MapGet("/topics/{topicId:guid}", async Task<Results<NotFound, Ok<TopicDto>>> (Guid topicId, BlogDbContext blogDbContext, IMapper mapper) =>
{
    var topic = await blogDbContext.Topics.FirstOrDefaultAsync(a => a.Id == topicId);

    if (topic == null)
    {
        return TypedResults.NotFound();
    }
    
    return TypedResults.Ok(mapper.Map<TopicDto>(topic));
});

app.MapPost("/topics", async (BlogDbContext blogDbContext, IMapper mapper, TopicCreationDto topic) =>
{
    var topicEntity = mapper.Map<Topic>(topic);
    blogDbContext.Add(topicEntity);
    await blogDbContext.SaveChangesAsync();

    var topicToReturn = mapper.Map<TopicDto>(topicEntity);
    return TypedResults.Ok(topicToReturn);
});

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>
           ().CreateScope())
{
    var context = serviceScope?.ServiceProvider.GetRequiredService<BlogDbContext>
        ();
    context.Database.EnsureDeleted();
    context.Database.Migrate();
}

app.Run();