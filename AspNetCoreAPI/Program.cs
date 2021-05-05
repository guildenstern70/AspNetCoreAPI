/*
 * 
 * AspNetCore API Template
 * (C) 2020-21 Alessio Saltarin
 * MIT LICENSE
 * 
 */

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace AspNetCoreAPI
{
    public class Program
    {
        protected Program() {}
        
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseSerilog((hostingContext, services, loggerConfiguration) => {
                    loggerConfiguration
                        .ReadFrom.Configuration(hostingContext.Configuration);
                }, writeToProviders: true);
    }
}
