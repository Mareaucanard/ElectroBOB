using Eletro_BOB_API.Context;
using Eletro_BOB_API.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

IConfigurationRoot configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

builder.Services.AddControllers();
Console.WriteLine(configuration.GetConnectionString("AreaDataBase"));
builder.Services.AddDbContext<AreaContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("AreaDataBase")));
try
{
    SqlConnection connection = new SqlConnection(configuration.GetConnectionString("AreaDataBase"));
    connection.Open();
    connection.Close();
}
catch (Exception e)
{
    Console.WriteLine(e);
}
builder.Services.AddEndpointsApiExplorer();
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

app.MapControllers();

app.Run();
