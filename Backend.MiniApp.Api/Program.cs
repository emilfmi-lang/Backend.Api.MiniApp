
using Backend.MiniApp.Api;
using Backend.MiniApp.Api.Data;
using Microsoft.Extensions.Configuration;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddServices(builder.Configuration);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    // 1. JSON s?n?dini yarad?r (openapi/v1.json)
    app.MapOpenApi();

    // 2. Scalar interfeysini yarad?r (/scalar/v1)
    app.MapScalarApiReference();
}
app.UseAuthorization();
app.MapControllers();

app.Run();
