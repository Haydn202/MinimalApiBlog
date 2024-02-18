using Microsoft.EntityFrameworkCore;
using MinimalApiBlog.DbContexts;
using MinimalApiBlog.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogDbContext>(o => o.UseSqlite(
    builder.Configuration["ConnectionStrings:BlogDBConnectionString"]));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseHttpsRedirection();
app.RegisterArticlesEndpoints();
app.RegisterTopicEndpoints();

app.Run();