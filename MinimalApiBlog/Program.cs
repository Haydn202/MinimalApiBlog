using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MinimalApiBlog.DbContexts;
using MinimalApiBlog.Models.Article;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogDbContext>(o => o.UseSqlite(
    builder.Configuration["ConnectionStrings:BlogDBConnectionString"]));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/Articles", async (BlogDbContext blogDbContext, IMapper mapper) =>
{
    return mapper.Map<ArticleDto>(await blogDbContext.Articles.ToListAsync());
});

app.MapGet("/Articles/{articleId:guid}", async (Guid articleId, BlogDbContext blogDbContext , IMapper mapper) =>
{
    return mapper.Map<ArticleDto>(await blogDbContext.Articles.FirstOrDefaultAsync(a => a.Id == articleId));
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