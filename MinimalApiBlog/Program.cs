using System.Net;
using Microsoft.EntityFrameworkCore;
using MinimalApiBlog.DbContexts;
using MinimalApiBlog.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogDbContext>(o => o.UseSqlite(
    builder.Configuration["ConnectionStrings:BlogDBConnectionString"]));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler(configureApplicationBuilder =>
    {
        configureApplicationBuilder.Run(
            async context =>
            {
                context.Response.StatusCode = (int)
                    HttpStatusCode.InternalServerError;
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("An unexpected problem happened.");
            });
    });
}

app.UseHttpsRedirection();

app.RegisterArticlesEndpoints();
app.RegisterTopicEndpoints();

app.Run();