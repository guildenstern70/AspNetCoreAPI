using System;
using AspNetCoreAPI.Models;
using AspNetCoreAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;

namespace AspNetCoreAPI.Test
{
    public class ServiceTest
    {
        private readonly IPersonService _personService;
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private readonly ITestOutputHelper _output;

        public ServiceTest(ITestOutputHelper output)
        {
            this._output = output;
            
            // Drop and Create Database
            new DbFixture().Initialize();
            
            this._output.WriteLine("Building services...");
            
            // Build services
            var services = new ServiceCollection()
                .AddDbContext<PersonContext>(options =>
                    options.UseSqlite("Data Source=aspnetcoreapi.db"))
                .AddLogging()
                .AddSingleton<IPersonService, PersonService>();  
            this._output.WriteLine("Building services DONE");
            
            // Get Persons Service
            this._output.WriteLine("Getting Person Service...");
            this._personService = services
                .BuildServiceProvider()
                .GetService<IPersonService>();
            this._output.WriteLine("Getting Person Service DONE");
        }
        
        [Fact]
        public void ListPersonsTest()
        {
            Assert.NotNull(_personService);
            var persons = _personService.GetAll();
            Assert.Equal(4, persons.Count);
        }
    }
}
