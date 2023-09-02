using Microsoft.EntityFrameworkCore;
using MinimalApiBlog.DbContexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BlogDbContext>(o => o.UseSqlite(
    builder.Configuration["ConnectionStrings:BlogDBConnectionString"]));

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

using (var serviceScope = app.Services.GetService<IServiceScopeFactory>
           ()
           ?.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<BlogDbContext>
        ();
    context.Database.EnsureDeleted();
    context.Database.Migrate();
}

app.Run();