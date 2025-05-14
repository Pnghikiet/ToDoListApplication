using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ToDoListApplication.Business.Services.Implements;
using ToDoListApplication.Business.Services.Interface;
using ToDoListApplication.DataAccess.Data;
using ToDoListApplication.DataAccess.Data.SeedData;
using ToDoListApplication.DataAccess.Identity;
using ToDoListApplication.DataAccess.Identity.SeedData;
using ToDoListApplication.DataAccess.Models;
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

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddIdentityCore<IdentityUser>(options =>
{

})
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddSignInManager<SignInManager<IdentityUser>>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:Key"])),
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Token:Issuer"],
            ValidateAudience = false
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddScoped<ITodoRepository<ToDoItem>, TodoRepository<ToDoItem>>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowCors");

var scope = app.Services.CreateScope();
var provider = scope.ServiceProvider;

var context = provider.GetRequiredService<ToDoContext>();
var identity = provider.GetRequiredService<AppIdentityDbContext>();
var usermanager = provider.GetRequiredService<UserManager<IdentityUser>>();
var logger = provider.GetRequiredService<ILogger<Program>>();

try
{
    await context.Database.MigrateAsync();
    await identity.Database.MigrateAsync();

    await ToDoItemSeedData.SeedToDoAsync(context);
    await AppIdentityDbContextSeedData.SeedDataAsync(usermanager);
}
catch (Exception e)
{
    logger.LogError(e, "An error occured during migrations");
}

app.Run();



