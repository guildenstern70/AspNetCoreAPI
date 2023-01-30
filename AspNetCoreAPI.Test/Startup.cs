/*
 * 
 * AspNetCore API Template
 * Copyright (C) 2020-23 Alessio Saltarin
 * MIT License - see LICENSE file
 * 
 */

using AspNetCoreApi.Models;
using AspNetCoreApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCoreApi.Test;

public class Startup
{
    private readonly IConfigurationRoot _configurationRoot;

    public Startup()
    {
        Console.WriteLine("Configuring Test Host...");
        this._configurationRoot = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json", false)
            .Build();
    }

    public void ConfigureHost(IHostBuilder hostBuilder)
    {
        Console.WriteLine("Configuring Host...");
        hostBuilder.ConfigureHostConfiguration(webHostBuilder => webHostBuilder
            .AddConfiguration(this._configurationRoot));
    }

    public void ConfigureServices(IServiceCollection services)
    {
        Console.WriteLine("Configuring Services...");
        // Routing must be lowercase
        services.AddRouting(options => options.LowercaseUrls = true);

        if (File.Exists("aspnetcoreapi.db"))
        {
            // Entity Framework Dependency Injection
            services.AddDbContextFactory<DataContext>(options =>
                options.UseSqlite("Data Source=aspnetcoreapi.db"));
        }
        else
        {
            Console.WriteLine("ERROR: Database file not found.");
            return;
        }
        
        services.AddScoped<DataContext>();
        services.AddTransient<IPersonService, PersonService>();
        
        Console.WriteLine("Test configuration done.");
    }

}