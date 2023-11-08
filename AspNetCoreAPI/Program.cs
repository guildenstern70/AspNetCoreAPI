/*
 * 
 * AspNetCore API Template
 * Copyright (C) 2020-23 Alessio Saltarin
 * MIT License - see LICENSE file
 * 
 */

using System.Reflection;
using AspNetCoreApi.Models;
using AspNetCoreApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Home Page
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Add services to the container.
builder.Services.AddControllers();

// Custom services
builder.Services.AddScoped<IPersonService, PersonService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "AspNetCore API",
        Description = "AspNet Core REST API Documentation",
        TermsOfService = new Uri("https://github.com/guildenstern70/AspNetCoreAPI"),
        Contact = new OpenApiContact
        {
            Name = "Contact",
            Url = new Uri("https://github.com/guildenstern70/AspNetCoreAPI")
        },
        License = new OpenApiLicense
        {
            Name = "License",
            Url = new Uri("https://github.com/guildenstern70/AspNetCoreAPI")
        }
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// Health check
builder.Services.AddHealthChecks();

// Logging
builder.Logging.ClearProviders();
builder.Logging.AddSimpleConsole(options =>
{
    options.IncludeScopes = true;
    options.SingleLine = false;
    options.TimestampFormat = "HH:mm:ss.ffff ";
});

// Routing must be lowercase
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Entity Framework Dependency Injection
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite("Data Source=aspnetcoreapi.db"));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.InjectStylesheet("/css/swaggerui/theme-flattop.css");
});
app.UseStaticFiles();
app.UseRouting();

// Endpoints
app.MapControllers();
app.MapBlazorHub();
app.MapHealthChecks("/health");
app.MapFallbackToPage("/_Host");

app.Run();

public partial class Program { }

