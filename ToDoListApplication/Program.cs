using Microsoft.EntityFrameworkCore;
using ToDoListApplication.Business.Services.Interface;
using ToDoListApplication.DataAccess.Data;
using ToDoListApplication.DataAccess.Data.SeedData;
using ToDoListApplication.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowCors", policy =>
    {
        policy.WithOrigins("https://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddDbContext<ToDoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ITodoRepository, TodoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowCors");

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



