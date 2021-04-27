using System;
using AspNetCoreAPI.Models;
using AspNetCoreAPI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;

namespace AspNetCoreAPI.Test
{
    public class ServiceTest
    {
        private readonly ServiceProvider _serviceProvider;

        public ServiceTest()
        {
            var dbFixture = new DbFixture();
            this._serviceProvider = dbFixture.ServiceProvider;
        }
        
        [Fact]
        public void ListPersonsTest()
        {
            var context = this._serviceProvider.GetService<PersonContext>();
            Assert.NotNull(context);
            var personService = new PersonService(null, context);
            Assert.NotNull(personService);
            var persons = personService.GetAll();
            Assert.Equal(5, persons.Count);
            context.Dispose();
        }
    }
}
