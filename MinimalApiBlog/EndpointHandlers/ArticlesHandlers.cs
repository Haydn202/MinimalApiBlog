using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MinimalApiBlog.DbContexts;
using MinimalApiBlog.Entities;
using MinimalApiBlog.Models.Article;

namespace MinimalApiBlog.EndpointHandlers;

public static class ArticlesHandlers
{
    public static async Task<Ok<IEnumerable<ArticleDto>>> GetArticlesAsync(
        BlogDbContext blogDbContext, 
        IMapper mapper)
    {
        return TypedResults.Ok(mapper.Map<IEnumerable<ArticleDto>>(await blogDbContext.Articles.ToListAsync()));
    }
    
    public static async Task<Results<NotFound, Ok<ArticleDto>>> GetArticleAsync(
        Guid articleId, 
        BlogDbContext blogDbContext, 
        IMapper mapper)
    {
        var article = await blogDbContext.Articles.FirstOrDefaultAsync(a => a.Id == articleId);

        if (article == null)
        {
            return TypedResults.NotFound();
        }
    
        return TypedResults.Ok(mapper.Map<ArticleDto>(article));
    }
    
    public static async Task<Ok<ArticleDto>> PostArticleAsync(
        BlogDbContext blogDbContext, 
        IMapper mapper, 
        ArticleCreationDto article)
    {
        var articleEntity = mapper.Map<Article>(article);
        blogDbContext.Add(articleEntity);
        await blogDbContext.SaveChangesAsync();

        var articleToReturn = mapper.Map<ArticleDto>(articleEntity);
        return TypedResults.Ok(articleToReturn);
    }

    public static async Task<Results<NotFound, Ok<ArticleDto>>> PutArticleAsync(
        Guid articleId, 
        BlogDbContext blogDbContext, 
        IMapper mapper, 
        ArticleUpdateDto articleForUpdate)
    {
        var article = await blogDbContext.Articles.FirstOrDefaultAsync(a => a.Id == articleId);

        if (article == null)
        {
            return TypedResults.NotFound();
        }

        mapper.Map(articleForUpdate, article);

        await blogDbContext.SaveChangesAsync();
        
        return TypedResults.Ok(mapper.Map<ArticleDto>(article));
    }

    public static async Task<Results<NotFound, NoContent>> DeleteArticleAsync(
        Guid articleId, 
        BlogDbContext blogDbContext)
    {
        var article = await blogDbContext.Articles.FirstOrDefaultAsync(a => a.Id == articleId);

        if (article == null)
        {
            return TypedResults.NotFound();
        }

        blogDbContext.Articles.Remove(article);
        await blogDbContext.SaveChangesAsync();

        return TypedResults.NoContent();
    }
}