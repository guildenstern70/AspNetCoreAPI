/*
 *
 * AspNetCore API Template
 * Copyright (C) 2020-25 Alessio Saltarin
 * MIT License - see LICENSE file
 *
 */

using System.Text.Json.Serialization;
using AspNetCoreAPI;
using AspNetCoreAPI.Components;
using AspNetCoreAPI.Models;
using AspNetCoreAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Razor services 
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add services to the container.
builder.Services.AddScoped<IPersonService, PersonService>();

// Add controllers
builder.Services.AddControllers();

// OpenAPI Service
builder.Services.AddOpenApi();

// Routing must be lowercase
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Health checks
builder.Services.AddHealthChecks();

// Entity Framework
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite("Data Source=aspnetcoreapi.db"));

var app = builder.Build();

// Anti-forgery
app.UseAntiforgery();

// NSwag UI
app.UseSwaggerUi(options =>
{
    options.DocumentTitle = "AspNet Core 9 API";
    options.Path = "/openapi";
    options.DocumentPath = "/openapi/v1.json";
});

// Routing and endpoints
app.MapOpenApi();
app.MapStaticAssets();
app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapHealthChecks("/healthz");

app.Run();

// The following is needed to make the app work with Unit Tests project AspNetCoreAPI.Tests
public partial class Program { }

