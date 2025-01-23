/*
 *
 * AspNetCore API Template
 * Copyright (C) 2020-25 Alessio Saltarin
 * MIT License - see LICENSE file
 *
 */

using AspNetCoreAPI.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit.Abstractions;

namespace AspNetCoreAPI.Test;

public class PersonServiceTest: IClassFixture<WebApplicationFactory<Program>>
{
    private readonly ITestOutputHelper _output;
    private readonly WebApplicationFactory<Program> _factory;
    
    public PersonServiceTest(ITestOutputHelper output,
        WebApplicationFactory<Program> factory)
    {
        this._output = output;
        this._factory = factory;
        this._output.WriteLine("Running tests in " + Directory.GetCurrentDirectory());
    }

    [Fact]
    public void DatabaseShouldExist()
    {
        File.Exists("aspnetcoreapi.db").Should().BeTrue();
    }

    [Fact]
    public async Task ListPersonsTest()
    {
        using var scope = _factory.Services.CreateScope();
        var scopedServices = scope.ServiceProvider;
        var personService = scopedServices.GetRequiredService<IPersonService>();
        
        this._output.WriteLine("List Persons...");
        personService.Should().NotBeNull();
        var size = await personService.Size();
        
        this._output.WriteLine("There are {0} persons", size);
        var persons = await personService.GetAll();
        persons.Should().NotBeNull();
        persons.Count.Should().BeGreaterThan(0);
    }
}
