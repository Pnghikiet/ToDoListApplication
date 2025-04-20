using Microsoft.EntityFrameworkCore;
using ToDoListApplication.DataAccess.Data;
using ToDoListApplication.DataAccess.Data.SeedData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<ToDoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var scope = app.Services.CreateScope();

var context = scope.ServiceProvider.GetRequiredService<ToDoContext>();

var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

try
{
    await context.Database.MigrateAsync();

    await ToDoItemSeedData.SeedToDoAsync(context);
}
catch (Exception e)
{
    logger.LogError(e, "An error occured during migrations");
}

app.Run();



