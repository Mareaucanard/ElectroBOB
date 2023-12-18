using Eletro_BOB_API.Context;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Configuration;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

IConfigurationRoot configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

builder.Services.AddControllers();
Console.WriteLine(configuration.GetConnectionString("AreaDataBase"));
builder.Services.AddDbContext<AreaContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("AreaDataBase")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

/*app.MapGet("/", () => "Hello, World!");
app.MapGet("/secret", (ClaimsPrincipal user) => $"Hello {user.Identity?.Name}. My secret")
    .RequireAuthorization();*/

app.MapControllers();

app.Run();
