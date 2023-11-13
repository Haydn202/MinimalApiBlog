using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MinimalApiBlog.DbContexts;
using MinimalApiBlog.Models.Article;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogDbContext>(o => o.UseSqlite(
    builder.Configuration["ConnectionStrings:BlogDBConnectionString"]));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/Articles", async Task<Ok<IEnumerable<ArticleDto>>> (BlogDbContext blogDbContext, IMapper mapper) =>
{
    return TypedResults.Ok(mapper.Map<IEnumerable<ArticleDto>>(await blogDbContext.Articles.ToListAsync()));
});

app.MapGet("/Articles/{articleId:guid}", async Task<Results<NotFound, Ok<ArticleDto>>> (Guid articleId, BlogDbContext blogDbContext, IMapper mapper) =>
{
    var article = await blogDbContext.Articles.FirstOrDefaultAsync(a => a.Id == articleId);

    if (article == null)
    {
        return TypedResults.NotFound();
    }
    
    return TypedResults.Ok(mapper.Map<ArticleDto>(article));
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