/*
 * 
 * AspNetCore API Template
 * (C) 2020-21 Alessio Saltarin
 * MIT LICENSE
 * 
 */

using AspNetCoreAPI.Config;
using AspNetCoreAPI.Models;
using AspNetCoreAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Serilog;

namespace AspNetCoreAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddMvc(c => c.Conventions.Add(new ApiExplorerIgnores()));
            services.AddControllers();
            
            // Entity Framework Dependency Injection
            services.AddDbContext<PersonContext>(options =>
                options.UseSqlite("Data Source=aspnetcoreapi.db"));
            
            // Services Dependency injection
            services.AddScoped<IPersonService, PersonService>();  

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspNetCoreAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AspNetCoreAPI v1"));

            // Serilog Logging
            app.UseSerilogRequestLogging();

            // Static files, routing and endpoints
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
